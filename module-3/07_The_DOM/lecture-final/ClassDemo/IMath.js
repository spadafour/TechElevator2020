function integermath(a,b)
{
    console.log(a/b);
}

function helloMars()
{
    const element = document.querySelector("table > tbody > tr > td");
    element.innerText = "Hello Mars!!";
}

function ragtime()
{
    const elements = document.querySelectorAll("td");
    elements.forEach((e) => {
        if(e.innerText.indexOf("gal") > -1)
        {
            e.innerHTML = "<strong>See</strong> you later!"
        }
    })
}

function grabValue()
{
    const element = document.getElementById("myinput");
    alert(element.value);
    element.value = "Duck season!";
}

function changeColor()
{
    const element = document.querySelector(".blue");
    element.classList.remove("blue");
    element.classList.add("green");
}

function addElement()
{
    const element = document.createElement("p");
    element.innerText = "First";
    const referenceElement = document.getElementById("container");
    referenceElement.insertAdjacentElement("beforebegin",element);
    element.innerText = "Second";
    referenceElement.insertAdjacentElement("afterbegin",element);
    element.innerText = "Third";
    referenceElement.insertAdjacentElement("beforeend",element);
    element.innerText = "Fourth";
    referenceElement.insertAdjacentElement("afterend",element);

}