let barColors = ["red", "green", "blue", "orange", "brown", "#3e95cd",
    "#8e5ea2",
    "#3cba9f",
    "#e8c3b9",
    "#c45850",
    "#CD5C5C",
    "#40E0D0"];
let data = [];

getData();
async function getData() {
    const response = await fetch('https://63f629b7ab76703b15b97dd7.mockapi.io/api/data/data')
    const data = await response.json();
    console.log(data);
    let length = data.length
    console.log(length);

    let labels = [];
    let values = [];
    for (let i = 0; i < length; i++) {
        labels.push(data[i].term)
        values.push(data[i].searched)
    }
    new Chart("myChart", {
        type: "bar",
        data: {
            labels: labels,
            datasets: [{
                backgroundColor: barColors,
                data: values,
            }]
        },
        options: {
            legend: { display: false },
            title: {
                display: true,
                text: "Term searched"
            }
        }
    });

}