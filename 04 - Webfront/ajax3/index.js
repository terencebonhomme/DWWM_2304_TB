async function main() {
    // FUNCTIONS

    function createTable() {
        let table = document.createElement('table');
        let thead = document.createElement('thead');        

        createTitles(thead);
        table.appendChild(thead);

        let tbody = document.createElement('tbody');

        createDataLine(tbody);
        createLastLine(tbody);

        table.appendChild(tbody);
        document.querySelector('body').appendChild(table);
    }

    function addEmptyCell(tr, width) {
        let td = document.createElement('td');
        td.colSpan = width;
        tr.appendChild(td);
    }

    function updateTable() {
        let table = document.getElementsByTagName('table')[0];
        table.remove();

        createTable();
    }

    function createTitles(thead) {
        let titles = ['EID', 'Full Name', 'Email', 'Monthly Salary', 'Year of birth', 'Actions'];

        titles.forEach(title => {
            let ele = document.createElement('th');
            ele.textContent = title;
            if (title == 'Monthly Salary') {
                let sortBtn = document.createElement('button');
                sortBtn.id = 'sort-button';
                // sortBtn.className = 'action-button';
                let sortSvg = document.createElement('img');
                sortSvg.src = 'sort.svg';
                sortBtn.append(sortSvg);
                sortBtn.onclick = sort;
                ele.appendChild(sortBtn);
            }

            thead.appendChild(ele);
        });
    }

    function createDataLine(tbody){
        employees.forEach((employee) => {
            let tr = document.createElement('tr');

            let id = document.createElement('td');
            id.textContent = employee.id;
            tr.appendChild(id);

            let name = document.createElement('td');
            name.textContent = employee.employee_name;
            tr.appendChild(name);

            let email = document.createElement('td');
            email.textContent = calcEmail(employee);
            tr.appendChild(email);

            let monthlySalary = document.createElement('td');
            monthlySalary.textContent = calcMonthlySalary(employee) + ' €';

            tr.appendChild(monthlySalary);

            let yearBirth = document.createElement('td');;
            yearBirth.textContent = calcYearBirth(employee);
            tr.appendChild(yearBirth);

            let actions = document.createElement('td');

            let duplicateBtn = document.createElement('button');
            duplicateBtn.className = 'action-button';
            duplicateBtn.id = 'duplicate-button';
            duplicateBtn.textContent = 'Duplicate';
            let duplicateSvg = document.createElement('img');
            duplicateSvg.src = 'duplicate.svg';
            duplicateBtn.prepend(duplicateSvg);
            duplicateBtn.onclick = () => duplicateEmployee(employee);
            actions.appendChild(duplicateBtn);

            let deleteBtn = document.createElement('button');
            deleteBtn.className = 'action-button';
            deleteBtn.id = 'delete-button';
            deleteBtn.textContent = 'Delete';
            let deleteSvg = document.createElement('img');
            deleteSvg.src = 'delete.svg';
            deleteBtn.prepend(deleteSvg);
            deleteBtn.onclick = () => deleteEmployee(employee);
            actions.appendChild(deleteBtn);

            tr.appendChild(actions);
            tbody.appendChild(tr);
        });
    }

    function createLastLine(tbody) {
        let tr = document.createElement('tr');
        tr.className = 'table-last-line';

        let total = document.createElement('td');
        total.textContent = employees.length;
        tr.appendChild(total);

        addEmptyCell(tr, 2);

        let sumMonthlySalary = document.createElement('td');
        sumMonthlySalary.textContent = calcSumMonthSalary();
        tr.appendChild(sumMonthlySalary);

        addEmptyCell(tr, 2);

        tbody.appendChild(tr);
    }

    function calcSumMonthSalary() {
        let sumMonthEmployeesSalary = 0;
        employees.forEach(emp => {
            let monthEmployeesSalary = calcMonthlySalary(emp)
            sumMonthEmployeesSalary += monthEmployeesSalary;
        });
        sumMonthEmployeesSalary = Number(sumMonthEmployeesSalary.toFixed(2, '0')) + ' €';

        return sumMonthEmployeesSalary;
    }

    function calcMonthlySalary(employee) {
        let monthlyEmployeeSalary = employee.employee_salary / 12;
        monthlyEmployeeSalary = Number(monthlyEmployeeSalary.toFixed(2, '0'));

        return monthlyEmployeeSalary;
    }

    function calcEmail(employee) {
        let firstname = employee.employee_name.split(" ")[0].toLowerCase();
        let name = employee.employee_name.split(" ")[1].toLowerCase();
        let email = firstname[0] + '.' + name + '@email.com';

        return email;
    }

    function calcYearBirth(employee) {
        let currentYear = new Date().getFullYear();
        let yob = currentYear - employee.employee_age;
        return yob;
    }

    function duplicateEmployee(/*employees,*/ employee) {
        let emp = Object.assign({}, employee);
        emp.id = employees.length + 1;
        employees.push(emp);
        updateTable();
    }

    /**
     * Supprimer l'employée de la ligne
     * 
     * @param {*} employee 
     */
    function deleteEmployee(employee) {
        // supprimer un employé donné du tableau d'objets

        let index = 0;
        for (let i = 0; i < employees.length; i++) {
            if (employees[i] == employee) {
                index = i;
            }
        }
        employees.splice(index, 1);

        updateTable();
    }

    /**
     * Classer
     */
    function sort() {
        let b;

        if (!descSorted) {
            b = employees.sort(function (a, b) { 
                return b.employee_salary - a.employee_salary; 
            });
            descSorted = true;
        } else {
            b = employees.sort(function (a, b) { 
                return a.employee_salary - b.employee_salary; 
            })
            descSorted = false;
        }

        employees = b;

        updateTable();
    }

    function checkEmployeeExist() {
        return employees.length > 0;
    }

    // TRAITEMENT

    let descSorted = false;

    // 1. récupérer le json

    const response = await fetch("employees.json");
    let employeesJson = await response.json();
    let employees = employeesJson.data;    

    // 2. créer une table

    createTable();
}

// EXECUTION

main();