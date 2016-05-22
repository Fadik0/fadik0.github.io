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
    
}

function newGraphical(){
    document.getElementById('mlr').innerHTML = '';
    var simplex = document.createElement('div');
    simplex.className = 'container-fluid';
    simplex.setAttribute('id','simplex');
    document.getElementById('mlr').appendChild(simplex);
    createPanel('Выбор начальных параметров', 'a', 'Next', 'a()');
    AddInitialParametrs('a');
}