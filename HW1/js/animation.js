var elUsername = document.getElementById('username');
var elMsg1 = document.getElementById('feedback1');
var elEmail = document.getElementById('email');
var elMsg2 = document.getElementById('feedback2');
var elAge = document.getElementById('age');
var elMsg3 = document.getElementById('feedback3');

function checkUsername(){
    var user = elUsername.value;
    var i;
    for(i = 0; i< user.length; i++){
        if((user.charCodeAt(i) >= 65 && user.charCodeAt(i) <= 90) || (user.charCodeAt(i) >= 97 && user.charCodeAt(i) <=122)|| (user.charCodeAt(i) >= 49 && user.charCodeAt(i) <= 57)){
            elMsg1.textContent = '';
        }
        else 
        {
            elMsg1.className = 'warning';
            elMsg1.textContent = "Invalid username";
            break;
        }
    }
}
function tipUsername() {
    elMsg1.className = 'tip';
    elMsg1.innerHTML = 'Username must be alphanumeric';
}

function checkEmail(){
    var email = elEmail.value;
    var count =0;
    var i;
    for(i=0; i< email.length; i++)
    {
        if(email.charCodeAt(i) == 64)
        {
            count = 1;
            break;
        }
    }
    if (count == 0 ){
        elMsg2.className = 'warning';
        elMsg2.textContent = "Invalid Email";
    }
    else
    {
        elMsg2.textContent = '';
    }
}

function tipEmail() {
    elMsg2.className = 'tip';
    elMsg2.textContent = "must follow <string>@<string> format";
}


function checkAge() {
    var age = elAge.value;
    var i;
    var check = 1;
    for (i=0; i < age.length; i++)
    {
        if(age.charCodeAt(i) >= 48 && age.charCodeAt(i) <= 57)
        {

        }
        else
        {
            check = 0;
            elMsg3.ClassName = 'warning';
            elMsg3.innerHTML = "Invalid Age";
            break;
        }
    }
    if(age < 0 || age > 150 )
        {
            elMsg3.ClassName = 'warning';
            elMsg3.innerHTML = "Invalid Age";
        }
    else
    {
        elMsg3.textContent = '';
    }

}

function tipAge() {
    elMsg3.className = 'tip';
    elMsg3.textContent = "Age must be between 0 and 150";
}
elUsername.addEventListener('focus',tipUsername,false);
elUsername.addEventListener('blur', checkUsername, false);

elEmail.addEventListener('focus',tipEmail,false);
elEmail.addEventListener('blur',checkEmail, false);

elAge.addEventListener('focus',tipAge,false);
elAge.addEventListener('blur',checkAge, false);



