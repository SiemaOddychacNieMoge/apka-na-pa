var data = [];

async function wezdanejol() {
  const res = await fetch('/data');

  const body = await res.json();

  data = body;

  for (var i = 0; i < data.length; i++) {
    document.getElementById('stacja').innerHTML +=
      '<option value="' + i + '">' + data[i].name + '</option>';
  }
}

wezdanejol();

const stacjaselect = document.getElementById('stacja');

stacjaselect.onchange = function (e) {
  var i = parseInt(stacjaselect.value);
  document.getElementById('nazwa').innerHTML = data[i].name;
  document.getElementById('temp').innerHTML = 'Temperatura: ' + data[i].temp;
  document.getElementById('opis').innerHTML = 'Opis: ' + data[i].description;
  document.getElementById('cisnienie').innerHTML =
    'Cisnienie: ' + data[i].pressure;
  document.getElementById('wiatr').innerHTML = 'Wiatr: ' + data[i].wind;
};
