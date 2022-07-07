
$(document).ready(function () {

    $.getJSON('api/OtherGet/GetCountry')
        .done(function (data) {
            let countryArray = data;
            let countrySelectElement = document.getElementById("countrySelect");
            let countrySelectElement2 = document.getElementById("countrySelect2");

            countryArray.forEach(function (value) {
                countrySelectElement.appendChild(new Option(value.country, value.countryId));
                countrySelectElement2.appendChild(new Option(value.country, value.countryId));

            });
        });

});


document.addEventListener("DOMContentLoaded", function (event) {

    document.getElementById("query1").addEventListener("click", function () {
        let select = document.getElementById('countrySelect');
        let selectValue = parseInt(select.options[select.selectedIndex].value);

        getDefenseData(selectValue);
    });

    document.getElementById("query2").addEventListener("click", function () {
        let select = document.getElementById('countrySelect2');
        let selectValue = parseInt(select.options[select.selectedIndex].value);

        getUniversiyandScoreData(selectValue);
    });
});


function getTenUnversityandRankArray() {
    $.getJSON('api/OtherGet/Join2')
        .done(function (data) {

            let table = document.getElementById("table1");
            $("#table1").empty();

            th = document.createElement('th');
            th.innerHTML = "Institution";
            table.appendChild(th);

            th2 = document.createElement('th');
            th2.innerHTML = "Ranking";
            table.appendChild(th2);

            generateTable(table, data)

            test = data

        });
};


function getDefenseData(selectValue) {
    $.getJSON('api/OtherGet/Test/' + selectValue)
        .done(function (data) {
            let table = document.getElementById("table2");
            console.log(data);

            let row = table.insertRow();
            $.each(data, function (key, item) {

                let cell = row.insertCell();
                let text = document.createTextNode(item);
                cell.appendChild(text);
            });

        });
}



function getUniversiyandScoreData(selectValue) {
    $.getJSON('api/OtherGet/Test2/' + selectValue)
        .done(function (data) {
            $("#table3").empty();
            $("#totalScore").empty();

            let table = document.getElementById("table3");
            th = document.createElement('th');
            th.innerHTML = "Second";
            table.appendChild(th);

            th2 = document.createElement('th');
            th2.innerHTML = "Score";
            table.appendChild(th2);

            th3 = document.createElement('th');
            th3.innerHTML = "Ranking";
            table.appendChild(th3);

            console.log(data);
            generateTable(table, data)

            var totalArray = data
            var totalNum = 0; 
            totalArray.forEach(element => {
                totalNum += element["score"]
            });

            let totalScore = document.getElementById("totalScore");
            var textToAdd = document.createTextNode("Total Education Score: " + parseInt(totalNum));

            totalScore.appendChild(textToAdd);
        });
}


function generateTable(table, data) {
    for (let element of data) {
        let row = table.insertRow();
        for (key in element) {
            let cell = row.insertCell();
            let text = document.createTextNode(element[key]);
            cell.appendChild(text);
        }
    }
}

