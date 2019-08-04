const express = require('express')
const app = express()
const port = 3000

function Cap(s1) {
    return s1.split(" ")
        .map( e => e.substring(0,1).toUpperCase()  + e.substring(1))
        .join(" ")
}

app.use(express.json()) 
app.use(express.urlencoded({ extended: true }))

app.post('/', function(req,res) {
    console.log(req.body);
    res.send(Cap(req.body.text))
})

app.listen(port, () => console.log('ehal;kjfadsfd'))