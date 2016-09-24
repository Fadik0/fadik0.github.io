//Класс Симплесного Метода
function Simplex() {
    this.variables = 2;
    this.restrictions = 3;
    this.matrix = [
        [20, 2, 3, 1, 0, 0],
        [30, 4, 1, 0, 1, 0],
        [40, 3, 5, 0, 0, 1],
        [0, -6, -5, 0, 0, 0], 
    ];
    this.attitude = [0, 0, 0, 0, 0];
    this.column = 1;
    this.line = 0;
    
    this.setVariables = function(variables) {
        this.variables = variables;
    };
    
    this.setRestrictions = function(restrictions) {
        this.restrictions = restrictions;        
    };
    
    this.setColum = function(line) {
        this.column = column;
    };
    
    this.setLine = function(column) {
        this.line = line;        
    };
    
    this.setCellMatrix = function(i,j, val) {     
        this.matrix[i][j] = val;       
    }
    
    //Функция поиска ведущей строки
    this.findColum = function() {
        var value = 0;
        for (var i = 1; i <= this.variables; i++) {
        if (value > this.matrix[this.restrictions][i]){
            column = i;
            value = this.matrix[this.restrictions][i];   
        } 
    }
    };

    //Функция поиска ведущей строки
    this.findLine = function() {
        var value = 10000000;
        for (var i = 0; i < this.restrictions; i++) {
            var n = this.matrix[i][0] / this.matrix[i][this.column];
            this.attitude[i] = Math.round(n * 100) / 100;                  
            if (value > n){
                line = i;
                value = n;
            }               
        }
    };
    
    //Создание матрицы нужного размера заполненую 0 
    this.createMatrix = function() {
        this.matrix = [];
        for (var i = 0; i <= this.restrictions; i++) {
            var b = [];
            for (var j = 0; j <= this.variables + this.restrictions; j++) {
                b.push(0);
            }
            this.matrix.push(b);     
        }
    };
    
    //Поиск новой матрицы
    this.findMatrix = function() {
        //Запоминаем старый вид матрицы
        var oldmatrix = $.extend(true, [], this.matrix);            
        //Перерасчитываем ведущую строку         
        for (var i = 0; i < this.variables + this.restrictions; i++) {
            var n = oldmatrix[this.line][i] / oldmatrix[this.line][this.column]; 
            this.matrix[this.line][i] = Math.round(n * 100) / 100;  
        }
        //Перерасчитываем все остальные элементы
        for (var i = 0; i <= this.restrictions; i++){
            if(line != i)
                for (var j = 0; j < this.variables + this.restrictions; j++){   
                    var n = oldmatrix[i][j] - (oldmatrix[this.line][j] * oldmatrix[i][this.column]) / oldmatrix[this.line][this.column]; 
                    console.log(n);
                    this.matrix[i][j] = Math.round(n * 100) / 100;
                }
        }      
    };
    
    this.finish = function() {
        var result = true;
        for (var i = 1; i <= this.variables; i++){            
            if (this.matrix[this.restrictions][i] < 0){
                result = false;             
            }
        };
        return result;
    };
};


Graphical = function() {
    this.restrictions = 3;
    this.variables = 2;
    /*
    this.createMatrix = function() {
        this.matrix = [];
        for (var i = 0; i <= this.restrictions; i++) {
            var b = [];
            for (var j = 0; j <= this.variables + this.restrictions; j++) {
                b.push(0);
            }
            this.matrix.push(b);     
        }
    };    */
    
    this.matrix = [
        [20, 2, 3],
        [30, 4, 1],
        [40, 3, 5],
        [0, -6, -5], 
    ];
    
    this.height = 600, 
    this.width = 600, 
    this.margin = 30;
    this.maxX = 650;
    this.maxY = 650;
    
    this.svg;
    this.xAxisLength;
    this.yAxisLength;
    this.gtooltip;
    this.xAxis;
    this.yAxis;
    
    //Функция создания области
    this.createSVG = function() {
        this.svg = d3.select("#graph")
        .append("svg")
        .attr("class", "axis")
        .attr("width", this.width)
        .attr("height", this.height);       
    };
    
    //Функция создания подсказки
    this.createToolTip = function() {
        this.gtooltip = d3.select("#graph")
        .append("kbd")   
        .attr("class", "tooltip")               
        .style("opacity", 0)
        .style("font", "12px sans-serif");
    };

    //Функция интерполяции значений на ось Х  
    var scaleX = d3.scale.linear()
        .domain([0, this.maxX])
        .range([0, this.xAxisLength]);

    //Функция интерполяции значений на ось Y
    var scaleY = d3.scale.linear()
        .domain([this.maxY, 0])
        .range([0, this.yAxisLength]);
    
    //Функция создания осей и сетки
    this.createXY = function() {
        this.xAxisLength = this.width - 2 * this.margin; 
        this.yAxisLength = this.height - 2 * this.margin;
        this.xAxis = d3.svg.axis().scale(scaleX).orient("bottom");
        this.yAxis = d3.svg.axis().scale(scaleY).orient("left");
        this.svg.append("g").attr("class", "x-axis")
            .attr("transform", "translate(" + this.margin + "," + (this.height / 2)  + ")")
            .call(this.xAxis);
        this.svg.append("g")       
            .attr("class", "y-axis")
            .attr("transform", "translate(" + (this.width / 2) + "," + this.margin  + ")")
            .call(yAxis);
        d3.selectAll("g.x-axis g.tick")
            .append("line")
            .classed("grid-line", true)
            .attr("x1", 0)
            .attr("y1", this.yAxisLength / 2)
            .attr("x2", 0)
            .attr("y2", - this.yAxisLength / 2);
        d3.selectAll("g.y-axis g.tick")
            .append("line")
            .classed("grid-line", true)
            .attr("x1", - (this.xAxisLength / 2))
            .attr("y1", 0)
            .attr("x2", (this.xAxisLength / 2))
            .attr("y2", 0);
    }

    //Функция создания новой линии
    this.createLine = function(x1, y1, x2, y2, color) { 
        this.svg.append("line")
            .style("stroke", color)
            .style("stroke-width", "2")
            .attr("x1", scaleX(x1) + this.margin)
            .attr("y1", scaleY(y1) + this.margin)
            .attr("x2", scaleX(x2) + this.margin)
            .attr("y2", scaleY(y2) + this.margin);
        this.append("circle")
            .attr("class", "dot")
            .attr("r", 3)
            .attr("cx", this.scaleX(x1) + this.margin)
            .attr("cy", this.scaleY(y1) + this.margin)
            .on("mouseover", function(d) {      
                this.gtooltip.transition()        
                    .duration(200)      
                    .style("opacity", .9);      
                this.gtooltip.html(x1 + ", "  + y1)  
                    .style("left", (d3.event.pageX) + "px")     
                    .style("top", (d3.event.pageY - 28) + "px");    
                })                  
            .on("mouseout", function(d) {       
                this.gtooltip.transition()        
                    .duration(500)      
                    .style("opacity", 0);   
            });
        this.svg.append("circle")
            .attr("class", "dot")
            .attr("r", 3)
            .attr("cx", this.scaleX(x2) + this.margin)
            .attr("cy", this.scaleY(y2) + this.margin)
            .on("mouseover", function(d) {      
                this.gtooltip.transition()        
                    .duration(200)      
                    .style("opacity", .9);      
                this.gtooltip.html(x2 + ", "  + y2)  
                    .style("left", (d3.event.pageX) + "px")     
                    .style("top", (d3.event.pageY - 28) + "px");    
                })                  
            .on("mouseout", function(d) {       
                this.gtooltip.transition()        
                    .duration(500)      
                    .style("opacity", 0);   
            });
    }   
};

//Случаное число от min до max
function randomInteger(min, max) {
    var rand = min + Math.random() * (max + 1 - min);
    rand = Math.floor(rand);
    return rand;
}

//Создание кнопки c заголовком и функцией
function createButton(title, func){
    var button = document.createElement('input');
    button.className = 'btn btn-block';
    button.setAttribute('type', 'button');
    button.setAttribute('value', title);
    button.setAttribute('onClick', func);   
    return button;
}

//Создание текстового поля 
function createTextBox(id){
    var textBox = document.createElement('input');
    textBox.className = 'form-control';
    textBox.setAttribute('type', 'text');
    textBox.setAttribute('id', id);
    return textBox;
}

//Создание поля с выбором числа
function createSelectBox(text, id, min, max){
    var selectBox = document.createElement('div');
    selectBox.className = 'form-group';
    var label = document.createElement('label');
    label.setAttribute('for',  id);
    label.textContent = text;
    selectBox.appendChild(label);
    var select = document.createElement('select');
    select.className = 'form-control';
    select.setAttribute('id', id);
    for (var i = min; i <= max; i++) {
        var option = document.createElement('option');
        option.textContent = i;
        select.appendChild(option);
    }
    selectBox.appendChild(select);
    return selectBox;
}

//Создание панели 
function createPanel(panel_title, body_id, button_title, button_func){
    var spoiler_id = randomInteger(100, 10000);  
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
    panel.appendChild(spoiler);  
    return panel;
}

//Добавление таблицы для ввода данных на нужную панель 
function addInitialTable(body_id, restrictions, variables) {        
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

function addСurrentTableSimplex(body_id) { 
    //Добавляем заголовки столбцов 
    var tr = document.createElement('tr');
    var th = document.createElement('th');    
    th.textContent = 'Базис';
    tr.appendChild(th);       
    for (var i = 1; i <= simplex.variables; i++) {
        th = document.createElement('th');
        th.textContent = 'x' + i;
        tr.appendChild(th);
    }    
    for (var i = 1; i <= simplex.restrictions; i++) {
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
    for (var i = 0; i <= simplex.restrictions; i++) {
        var tr = document.createElement('tr');
        for (var j = 0; j <= simplex.variables + simplex.restrictions; j++) {
            var td = document.createElement('td');
            td.textContent = simplex.matrix[i][j];
            tr.appendChild(td);  
        }                
        var td = document.createElement('td');
        td.textContent = simplex.attitude[i];
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
    p.textContent = 'Ведущий столбец x' + (simplex.column) + ', ведущая строка ' + (simplex.line + 1);
    data.appendChild(p);
}

var step = 0;
var simplex;
var graphical;
var main;

function newSimplex(){   
    main.innerHTML = '';
    var panel = createPanel('Выбор начальных параметров', step);
    main.appendChild(panel);
    var box = document.getElementById(step);
    var select = createSelectBox('Кол-во ограничений:','restrictions', 2, 5);
    box.appendChild(select);
    select = createSelectBox('Кол-во переменных:','variables', 2, 5);
    box.appendChild(select);
    var btn = createButton('Далее', 'nextStepSimplex()');
    panel.appendChild(btn);
    simplex = new Simplex();
    step = 1;      
}

function nextStepSimplex() {
    switch(step) {
        case 1:
            simplex.setVariables(+document.getElementById("variables").value);
            simplex.setRestrictions(+document.getElementById("restrictions").value); 
            var panel = createPanel('Выбор данных решения', step);
            main.appendChild(panel);
            var box = document.getElementById(step);            
            addInitialTable(step, simplex.restrictions, simplex.variables);
            var btn = createButton('Далее', 'nextStepSimplex()');
            panel.appendChild(btn);
            ++step;
            break;                 
        case 2:
            simplex.createMatrix();       
            for (var i = 0; i < simplex.restrictions; i++) {
                var num = 0;
                var id = 'r' + (i + 1);     
                num = +document.getElementById(id).value;
                simplex.setCellMatrix(i, 0, num);
                for (var j = 1; j <= simplex.variables; j++) {
                    id = 'x' + (i + 1) + j;
                    num = +document.getElementById(id).value;
                    simplex.setCellMatrix(i, j, num);
                }
                for (var k = 0 ; k < simplex.restrictions; k++) {
                    if (i == k)
                        simplex.matrix[i][k + 1 + simplex.variables] = 1;
                    else
                        simplex.matrix[i][k + 1 + simplex.variables] = 0;
                }        
            }
            for (var i = 1; i <= simplex.variables; i++) {
                var num = 0;
                var id = 'f' + i;
                num = +document.getElementById(id).value;
                simplex.setCellMatrix(simplex.restrictions, i ,num);            
            }
            simplex.findColum();
            simplex.findLine();
            var panel = createPanel('Выбор начальных параметров', step);
            main.appendChild(panel);
            var box = document.getElementById(step);            
            addСurrentTableSimplex(step);
            var btn = createButton('Далее', 'nextStepSimplex()');
            panel.appendChild(btn);          
            ++step;
            break;           
        case 3:
            var finish = simplex.finish();
            if (!finish){
                simplex.findColum();
                simplex.findLine();
                simplex.findMatrix();
                addСurrentTableSimplex(step - 1);
                break;
            }                      
        case 4:
            ++step;
            break;
        default:
            
            break;
    };
};

function newGraphical(){   
    main.innerHTML = '';
    var panel = createPanel('Выбор начальных параметров', step);
    main.appendChild(panel);
    var box = document.getElementById(step);
    var select = createSelectBox('Кол-во ограничений:','restrictions', 2, 5);
    box.appendChild(select);
    var btn = createButton('Далее', 'nextStepGraphical()');
    panel.appendChild(btn);
    graphical = new Graphical();
    step = 1;      
}

function nextStepGraphical() {
    simplex = null;
    if (graphical == null) step = 0;
    switch(step) {
        case '0':
            simplex.setVariables(+document.getElementById("variables").value);
            simplex.setRestrictions(+document.getElementById("restrictions").value); 
            var panel = createPanel('Выбор данных решения', step);
            main.appendChild(panel);
            var box = document.getElementById(step);         
            addInitialTableSimplex(step);
            var btn = createButton('Далее', 'nextStepGraphical()');
            panel.appendChild(btn);
            ++step;           
            break; 
        case '1':
            for (var i = 0; i < simplex.restrictions; i++) {
                var num = 0;
                var id = 'r' + (i + 1);     
                num = +document.getElementById(id).value;
                simplex.setCellMatrix(i, 0, num);
                for (var j = 1; j <= simplex.variables; j++) {
                    id = 'x' + (i + 1) + j;
                    num = +document.getElementById(id).value;
                    simplex.setCellMatrix(i, j, num);
                }
                for (var k = 0 ; k < simplex.restrictions; k++) {
                    if (i == k)
                        simplex.matrix[i][k + 1 + simplex.variables] = 1;
                    else
                        simplex.matrix[i][k + 1 + simplex.variables] = 0;
                }        
            }
            graphical.createSVG();
            graphical.createToolTip();
            graphical.createXY();
            graphical.createLine();
            graphical.createLine();       
            break;                                                   
        default:
            alert(step);
            break;
    };
};

document.addEventListener('DOMContentLoaded', function(){    
    var button = document.getElementById("lp-simplex");
    if (button != null){
        button.setAttribute('onClick', 'newSimplex()'); 
    }
    button = document.getElementById("lp-graphical");
    if (button != null){
        button.setAttribute('onClick', 'newGraphical()'); 
    }
    main = document.getElementById("lp-main");    
});

