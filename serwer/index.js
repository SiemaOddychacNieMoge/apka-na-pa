const express = require('express');
const fs = require('fs');
const cors = require('cors');

const app = express();

app.use(cors());
app.use(express.static('strona'));

app.get('/data', (req, res) => {
  fs.readFile('data.json', function (err, data) {
    if (err) {
      console.log(err);
      return res.json({});
    }
    var json = JSON.parse(data.toString());

    var result = [];

    for (var i = 0; i < json.length; i++) {
      result.push({
        name: json[i].name,
        temp: json[i].main.temp,
        wind: json[i].wind.speed,
        description: json[i].weather[0].main,
        pressure: json[i].main.pressure
      });
    }

    res.json(result);
  });
});

app.listen(8080);
