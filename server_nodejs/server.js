var express = require('express');
var crypto = require('crypto-js');
var _ = require ('underscore');
var bodyParser = require('body-parser');
var app = express();

app.use(bodyParser.json());
app.use(bodyParser.urlencoded({ extended: true }));

app.get ('/',function(req,res){
  var bytes = req.query.id;
  console.log("Connexion...");
  console.log("Message to Unity: "+bytes);
  var data = {message:'Hello Unity'};
  var dataJSON = JSON.stringify(data);
  res.send(dataJSON);
})

app.post('/',function(req,res){
  var body = req.body;
  //var decryptedMessage = _.pick("message");
  //var decryptedMessage = bytes.toString(crypto.enc.Utf8);
  console.log("Message from Unity: "+req.body.message);
  res.status(200).send("Info Loaded");
});

app.listen(3000,function(){
  console.log("App is working")
});
