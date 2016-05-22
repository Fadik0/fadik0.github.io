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

function GetEnterData(){
    variables = +document.getElementById("variables").value;
    restrictions = +document.getElementById("restrictions").value;
}

function randomInteger(min, max) {
    var rand = min + Math.random() * (max + 1 - min);
    rand = Math.floor(rand);
    return rand;
}

function createButton(title, func){
    var button = document.createElement('input');
    button.className = 'btn btn-info btn-block';
    button.setAttribute('type', 'button');
    button.setAttribute('value', title);
    button.setAttribute('onClick', func);   
    return button;
}

function createTextBox(id){
    var textBox = document.createElement('input');
    textBox.className = 'form-control input-sm';
    textBox.setAttribute('type', 'text');
    textBox.setAttribute('id', id);
    return textBox;
}

//Создание панели 
function createPanel(panel_title, body_id, button_title, button_func){
    var spoiler_id = randomInteger(0, 100);  
    var panel = document.createElement('div');
    panel.className = 'panel panel-default';    
    var pheading = document.createElement('div');
    pheading.className = 'panel-heading';
    var title = document.createElement('a');
    title.setAttribute('href', '#' + spoiler_id);
    title.setAttribute('data-toggle', 'collapse');
    title.textContent = panel_title;
    pheading.appendChild(title);
    panel.appendChild(pheading);
    var spoiler = document.createElement('div');
    spoiler.className = 'collapse in';
    spoiler.setAttribute('id', spoiler_id);
    var pbody = document.createElement('div');
    pbody.className = 'panel-body';
    pbody.setAttribute('id', body_id); 
    spoiler.appendChild(pbody);
    var btn = createButton(button_title, button_func);
    spoiler.appendChild(btn);
    panel.appendChild(spoiler);  
    document.getElementById('simplex').appendChild(panel);
}

//Добавление таблицы для ввода данных на нужную панель                 
function AddInitialTable(body_id) {        
    var data = document.getElementById(body_id);
    data.innerHTML = '';
    var well = document.createElement('div');
    well.className = 'well well-sm';
    well.textContent = 'Первые ' + restrictions + ' строки это система уравнений ограничений, последняя строка целевая функция.';
    data.appendChild(well); 
    
    //Добавляем заголовки столбцов 
    var tr = document.createElement('tr');
    var th = document.createElement('th');           
    for (var i = 1; i <= variables; i++) {
        th = document.createElement('th');
        th.textContent = 'x' + i;
        tr.appendChild(th);
    }          
    th = document.createElement('th');
    th.textContent = 'Ограничение';
    tr.appendChild(th);  
    var thead = document.createElement('thead');
    thead.appendChild(tr);   
      
    //Добавляем значения строками 
    var tbody = document.createElement('tbody');   
    for (var i = 1; i <= restrictions; i++) {
        var tr = document.createElement('tr');
        for (var j = 1; j <= variables; j++) {
            var td = document.createElement('td');
            var tBox = createTextBox('x' + i + j);
            td.appendChild(tBox);
            tr.appendChild(td);
        }
        var td = document.createElement('td');
        var tBox = createTextBox('r' + i);
        td.appendChild(tBox);
        tr.appendChild(td);
        tbody.appendChild(tr);
    }
    var tr = document.createElement('tr'); 
    for (var i = 1; i <= variables; i++) {           
        var td = document.createElement('td');
        var tBox = createTextBox('f' + i);
        td.appendChild(tBox);     
        tr.appendChild(td);
        tbody.appendChild(tr);
    }
    
    //Добвляем заголовок и данные
    var table = document.createElement('table');
    table.className = 'table table-condensed table-striped';
    table.appendChild(thead);
    table.appendChild(tbody);
    
    var div = document.createElement('div');
    div.className = 'table-responsive';
    div.appendChild(table);
    
    var data = document.getElementById(body_id);
    data.appendChild(div);
}

//Добавление текущей таблицы решения
function AddСurrentTable(body_id) { 
//    Добавляем зоголовок таблицы
//    $('#basic-table').append('<caption>Начальная симплекс–таблица</caption>');

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
    var table = document.createElement('table');
    table.className = 'table table-bordered table-condensed';
    table.setAttribute('id', 'basic-table');
    table.appendChild(thead);
    table.appendChild(tbody);
    
    var div = document.createElement('div');
    div.className = 'table-responsive';
    div.appendChild(table);
    
    var data = document.getElementById(body_id);
    data.appendChild(div);
            
    var p = document.createElement('p');
    p.textContent = 'Ведущий столбец x' + (column) + ', ведущая строка ' + (line + 1);
    data.appendChild(p);
}

//Добавление полей для ввода начальных параметров
function AddInitialParametrs(body_id){
    var form = document.createElement('form');
    form.className = 'form';
    form.setAttribute('role', 'form');        
    var div = document.createElement('div');
    div.className = 'col-xs-3';
    var label = document.createElement('label');
    label.setAttribute('for', 'restrictions');
    label.textContent = 'Кол-во ограничений:';
    label.className = 'control-label';
    div.appendChild(label);
    var select = document.createElement('select');
    select.className = 'form-control input-sm';
    select.setAttribute('id', 'restrictions');
    for (var i = 2; i <= 5; i++) {
        var option = document.createElement('option');
        option.textContent = i;
        select.appendChild(option);
    }
    div.appendChild(select);
    form.appendChild(div);
    
    div = document.createElement('div');
    div.className = 'col-xs-3';
    var label = document.createElement('label');
    label.setAttribute('for', 'variables');
    label.textContent = 'Кол-во переменных:';
    div.appendChild(label);
    var select = document.createElement('select');
    select.className = 'form-control input-sm';
    select.setAttribute('id', 'variables');
    for (var i = 2; i <= 5; i++) {
        var option = document.createElement('option');
        option.textContent = i;
        select.appendChild(option);
    }
    div.appendChild(select);
    form.appendChild(div);
    
    var data = document.getElementById(body_id);
    data.appendChild(form);
}

//Создание начальной матрицы
function CreateMatrix() {
    //Создаем матрицу и заполняем 0
    var bmatrix = [];
    for (var i = 0; i <= restrictions; i++) {
        var b = [];
        for (var j = 0; j <= variables + restrictions; j++) {
            b.push(0);
        }
        bmatrix.push(b);     
    }
    //Получаем данные и записываем в матрицу
    for (var i = 0; i < restrictions; i++) {
        var num = 0;
        var id = 'r' + (i + 1);     
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
    for (var i = 1; i <= variables; i++) {
        var num = 0;
        var id = 'f' + i;
        num = +document.getElementById(id).value;
        bmatrix[restrictions][i] = num;            
    }
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
}

//Определяем ведушую строку
function getLine(){
    xline = 10000000;
    for (var i = 0; i < restrictions; i++) {
        var n = bmatrix[i][0] / bmatrix[i][column];
        attitude[i] = Math.round(n * 100) / 100;                  
        if (xline > n){
            line = i;
            xline = n;
        }               
    }
}

//Определяем ведуший столбец 
function getColumn(){
    var xcolumn = 0;
    for (var i = 1; i <= variables; i++) {
        if (xcolumn > bmatrix[restrictions][i]){
            column = i;
            xcolumn = bmatrix[restrictions][i];   
        } 
    } 
}

function a(){
    if (document.getElementById('b') == null)
        createPanel('Выбор начальных параметров', 'b', 'Next', 'b()')
    else
        document.getElementById('b').innerHTML = '';   
    GetEnterData();
    AddInitialTable('b');
}

function b(){
    if (document.getElementById('c') == null)
        createPanel('Выбор начальных параметров', 'c', 'Next', 'c()')
    else
        document.getElementById('c').innerHTML = '';  
    CreateMatrix();
    getColumn();
    getLine();    
    AddСurrentTable('c');
}

function c(){
    GetNewMatrix();
    getColumn();
    getLine();  
    AddСurrentTable('c');
}

function newSimplex(){
    document.getElementById('mlr').innerHTML = '';
    var simplex = document.createElement('div');
    simplex.className = 'container-fluid';
    simplex.setAttribute('id','simplex');
    document.getElementById('mlr').appendChild(simplex);
    createPanel('Выбор начальных параметров', 'a', 'Next', 'a()');
    AddInitialParametrs('a');
}