let allItemsIncomplete = true;
const pageTitle = 'My Shopping List';
const groceries = [
  { id: 1, name: 'Oatmeal', completed: false },
  { id: 2, name: 'Milk', completed: false },
  { id: 3, name: 'Banana', completed: false },
  { id: 4, name: 'Strawberries', completed: false },
  { id: 5, name: 'Lunch Meat', completed: false },
  { id: 6, name: 'Bread', completed: false },
  { id: 7, name: 'Grapes', completed: false },
  { id: 8, name: 'Steak', completed: false },
  { id: 9, name: 'Salad', completed: false },
  { id: 10, name: 'Tea', completed: false }
];

document.addEventListener('DOMContentLoaded', () => {

  /**
   * This function will get a reference to the title and set its text to the value
   * of the pageTitle variable that was set above.
   */
  function setPageTitle() {
    const title = document.getElementById('title');
    title.innerText = pageTitle;
  }

  /**
   * This function will loop over the array of groceries that was set above and add them to the DOM.
   */
  const ul = document.querySelector('ul');

  function displayGroceries() {
    groceries.forEach((item) => {
      const li = document.createElement('li');
      li.innerText = item.name;
      const checkCircle = document.createElement('i');
      checkCircle.setAttribute('class', 'far fa-check-circle');
      li.appendChild(checkCircle);
      ul.appendChild(li);
    });
  }

  setPageTitle();
  displayGroceries();


  const toggleAll = document.getElementById('toggleAll');
  let completedCount = 0;

  function flipToggleAll () {
    if (toggleAll.innerText == 'MARK ALL COMPLETE')
    {
      toggleAll.innerText = 'Mark All Incomplete';
    }
    else
    {
      toggleAll.innerText = 'Mark All Complete';
    }
  }

  function switchToCompleted(ev) {
    if (!ev.classList.contains('completed'))
    {
      if (ev.tagName == 'LI') {
        ev.classList.add('completed');
        ev.firstElementChild.classList.add('completed');
      }
      if (ev.tagName == 'I') {
        ev.classList.add('completed');
        ev.parentElement.classList.add('completed');
      }
      completedCount += 1;
      if (completedCount == ul.childElementCount)
      {
        flipToggleAll();
      }
    }
  }
  ul.addEventListener('click', (event) => {
    switchToCompleted(event.target);
  });

  function switchToIncomplete(ev) {
    if (ev.classList.contains('completed'))
    {
      if (ev.tagName == 'LI') {
        ev.classList.remove('completed');
        ev.firstElementChild.classList.remove('completed');
      }
      if (ev.tagName == 'I') {
        ev.classList.remove('completed');
        ev.parentElement.classList.remove('completed');
      }
      completedCount -= 1;
      if (completedCount == ul.childElementCount - 1)
      {
        flipToggleAll();
      }
    }
  }
  ul.addEventListener('dblclick', (event) => {
    switchToIncomplete(event.target);
  })

  toggleAll.addEventListener('click', (event) => {
    if (toggleAll.innerText == 'MARK ALL COMPLETE')
    {
      for (let i=0; i<ul.childElementCount; i++)
      {
        switchToCompleted(ul.children[i]);
      }
    }
    else if (toggleAll.innerText == "MARK ALL INCOMPLETE")
    {
      for (let i=0; i<ul.childElementCount; i++)
      {
        switchToIncomplete(ul.children[i]);
      }
    }
  });

});