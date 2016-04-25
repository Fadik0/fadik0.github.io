// Default Data
var bmatrix = [
    [20, 2, 3, 1, 0, 0],
    [30, 4, 1, 0, 1, 0],
    [40, 3, 5, 0, 0, 1],
    [0, -6, -5, 0, 0, 0], 
];

var variables = 2;
var restrictions = 3;

var attitude = [0, 0, 0, 0, 0];

var column = 1;
var line = 0;

function NewSimplex() {
    document.body.innerHTML = '';
    
}


//добавляем таблицу для ввода данных                     
function CreateEnterTable() {               
    variables = +document.getElementById("variables").value;
    restrictions = +document.getElementById("restrictions").value;
    
    var panel = document.createElement('div');
    panel.className = 'panel panel-default';
    var pheading = document.createElement('div');
    pheading.className = 'panel-heading';
    var title = document.createElement('a');
    title.setAttribute('href', '#b');
    title.setAttribute('data-toggle', 'collapse');
    title.textContent = 'Ввод начальных параметров';
    pheading.appendChild(title);
    panel.appendChild(pheading);
    var spoiler = document.createElement('div');
    spoiler.className = 'collapse in';
    spoiler.setAttribute('id', 'b');
    var pbody = document.createElement('div');
    pbody.className = 'panel-body';
    pbody.setAttribute('id', 'data');
    spoiler.appendChild(pbody);
    var input = document.createElement('input');
    input.className = 'btn btn-info btn-block';
    input.setAttribute('type', 'button');
    input.setAttribute('value', 'Построить базовую сиплекс-таблицу');
    input.setAttribute('onClick', 'CreatePanel()' );
    spoiler.appendChild(input);
    panel.appendChild(spoiler);
    document.getElementById('simplex').appendChild(panel);
    

    var data = document.getElementById('data');
    data.innerHTML = '';
    var well = document.createElement('div');
    well.className = 'well well-sm';
    well.textContent = 'Функции цели F(x)';
    data.appendChild(well);  
    for (var i = 1; i <= restrictions; i++) {
        var form = document.createElement('form');
        form.className = 'form-inline';
        form.setAttribute('role', 'form');        
        for (var j = 1; j <= variables; j++) {
            var div = document.createElement('div');
            div.className = 'form-group';
            var label = document.createElement('label');
            label.setAttribute('for', 'x' + i + j);
            label.textContent = 'x' + i;
            div.appendChild(label);
            var input = document.createElement('input');
            input.className = 'form-control';
            input.setAttribute('type', 'text');
            input.setAttribute('id', 'x' + i + j);
            input.setAttribute('placeholder', 'x' + j);
            div.appendChild(input);
            form.appendChild(div);
        }        
        var div = document.createElement('div');
        div.className = 'form-group';
        var label = document.createElement('label');
        label.setAttribute('for', 's' + i);
        label.textContent = '≤';
        div.appendChild(label);
        var input = document.createElement('input');
        input.className = 'form-control';
        input.setAttribute('type', 'text');
        input.setAttribute('id', 's' + i);
        input.setAttribute('placeholder', '≤');
        div.appendChild(input);
        form.appendChild(div);      
        data.appendChild(form);
        data.appendChild(document.createElement('br'));
    }   
      
    well = document.createElement('div');
    well.className = 'well well-sm';
    well.textContent = 'Функции цели F(x)';
    data.appendChild(well);     
    var form = document.createElement('form');
    form.className = 'form-inline';
    form.setAttribute('role', 'form');
    for (var i = 1; i <= variables; i++) {                       
        var div = document.createElement('div');
        div.className = 'form-group';
        var label = document.createElement('label');
        label.setAttribute('for', 'f' + i);
        label.textContent = 's' + i;
        div.appendChild(label);    
        var input = document.createElement('input');
        input.className = 'form-control';
        input.setAttribute('type', 'text');
        input.setAttribute('id', 'f' + i);
        input.setAttribute('placeholder', 's' + i);
        div.appendChild(input);
        form.appendChild(div);
    }
    data.appendChild(form);                    
}

//Создание понели под таблицу расчетов
function CreatePanel(){  
    if (document.getElementById('basic-table') !== null){
        document.getElementById('basic-table').innerHTML = '';
        CreateMatrix();
        return;
    }
            
    var panel = document.createElement('div');
    panel.className = 'panel panel-default';
    var pheading = document.createElement('div');
    pheading.className = 'panel-heading';
    var title = document.createElement('a');
    title.setAttribute('href', '#с');
    title.setAttribute('data-toggle', 'collapse');
    title.textContent = 'Расчет симплекс–таблицы';
    pheading.appendChild(title);
    panel.appendChild(pheading);
    var spoiler = document.createElement('div');
    spoiler.className = 'collapse in';
    spoiler.setAttribute('id', 'с');
    var pbody = document.createElement('div');
    pbody.className = 'panel-body';
    pbody.setAttribute('id', 'data');
    var table = document.createElement('table');
    table.className = 'table table-bordered table-condensed';
    table.setAttribute('id', 'basic-table');
    pbody.appendChild(table);   
    spoiler.appendChild(pbody);
    var input = document.createElement('input');
    input.className = 'btn btn-info btn-block';
    input.setAttribute('type', 'button');
    input.setAttribute('value', 'Следующий шаг');
    input.setAttribute('onClick', 'GetNewMatrix()' );
    spoiler.appendChild(input);
    panel.appendChild(spoiler);  
    document.getElementById('simplex').appendChild(panel);
    
    CreateTable();
}


function CreateMatrix() {
    //Создаем матрицу и заполняем 0
    var a = [];
    for (var i = 0; i <= restrictions; i++) {
        var b = [];
        for (var j = 0; j <= variables + restrictions; j++) {
            b.push(0);
        }
        a.push(b);     
    }
    bmatrix = $.extend(true, [], a); 
    
    //Получаем данные и записываем в матрицу
    for (var i = 0; i < restrictions; i++) {
        var num = 0;
        var id = 's' + (i + 1);     
        num = +document.getElementById(id).value;
        bmatrix[i][0] = num;
        for (var j = 1; j <= variables; j++) {
            id = 'x' + (i + 1) + j;
            num = +document.getElementById(id).value;
            bmatrix[i][j] = num;
        }
        for (var k = 0 ; k < restrictions; k++) {
            if (i == k)
                bmatrix[i][k + 1 + variables] = 1;
            else
                bmatrix[i][k + 1 + variables] = 0;
        }        
    }
    
    //bmatrix[restrictions][0] = 0;
    for (var i = 1; i <= variables; i++) {
        var num = 0;
        var id = 'f' + i;
        num = +document.getElementById(id).value;
        bmatrix[restrictions][i] = num;            
    }
    
    //Очиищаем таблицу, отрисовываем новую добавляем код 
    $('#basic-table').html('');    
    CreateTable();
}

//Отрисовка текущей таблицы решения
function CreateTable() { 
    //Добавляем зоголовок таблицы
    //$('#basic-table').append('<caption>Начальная симплекс–таблица</caption>');

    //Добавляем заголовки столбцов 
    var tr = document.createElement('tr');
    var th = document.createElement('th');    
    th.textContent = 'Базис';
    tr.appendChild(th);       
    for (var i = 1; i <= variables; i++) {
        th = document.createElement('th');
        th.textContent = 'x' + i;
        tr.appendChild(th);
    }    
    for (var i = 1; i <= restrictions; i++) {
        th = document.createElement('th');
        th.textContent = 'S' + i;
        tr.appendChild(th);
    }       
    th = document.createElement('th');
    th.textContent = 'Отношение';
    tr.appendChild(th);  
    var thead = document.createElement('thead');
    thead.appendChild(tr);   
      
    //Добавляем значения строками 
    var tbody = document.createElement('tbody');   
    for (var i = 0; i <= restrictions; i++) {
        var tr = document.createElement('tr');
        for (var j = 0; j <= variables + restrictions; j++) {
            var td = document.createElement('td');
            td.textContent = bmatrix[i][j];
            tr.appendChild(td);  
        }                
        var td = document.createElement('td');
        td.textContent = attitude[i];
        tr.appendChild(td);  
        tbody.appendChild(tr);
    }

    //Добвляем заголовок и данные
    var bt = document.getElementById('basic-table');
    bt.appendChild(thead);
    bt.appendChild(tbody);    
}


//Расчет новой матрицы
function GetNewMatrix() { 
    //Определяем нужен ли расчет
    var key = true;
    for (var i = 1; i <= variables; i++){
        if (bmatrix[restrictions][i] < 0)
            key = false;
    }
    if (key){
        return;
    }
    
    //Запоминаем старый вид матрицы
    var oldmatrix = $.extend(true, [], bmatrix);            

    //Определяем ведуший столбец                
    var xcolumn = 0;
    for (var i = 1; i <= variables; i++) {
        if (xcolumn > oldmatrix[restrictions][i]){
            column = i;
            xcolumn = oldmatrix[restrictions][i];
            
        } 
        console.log(column);
    }
    
    
    //Определяем ведушую строку
    xline = 10000000;
    for (var i = 0; i < restrictions; i++) {
        var n = oldmatrix[i][0] / oldmatrix[i][column];
        attitude[i] = Math.round(n * 100) / 100;                  
        if (xline > n){
            line = i;
            xline = n;
        }               
    }
    console.log(line);

    //Перерасчитываем ведущую строку         
    for (var i = 0; i < variables + restrictions; i++) {
        var n = oldmatrix[line][i] / oldmatrix[line][column]; 
        bmatrix[line][i] = Math.round(n * 100) / 100;  
    }

    //Перерасчитываем все остальные элементы
    for (var i = 0; i <= restrictions; i++){
        if(line != i)
            for (var j = 0; j < variables + restrictions; j++){   
                var n = oldmatrix[i][j] - (oldmatrix[line][j] * oldmatrix[i][column]) / oldmatrix[line][column]; 
                console.log(n);
                bmatrix[i][j] = Math.round(n * 100) / 100;

            }
    }

    //Отрисовываем полученную новую таблицу
    CreateTable();                    
}