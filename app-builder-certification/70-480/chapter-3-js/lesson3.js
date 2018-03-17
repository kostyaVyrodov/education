const pizzaParts = new Array();
console.log(pizzaParts)
pizzaParts[0] = 'pepperoni';
pizzaParts[1] = 'onion';
pizzaParts[2] = 'bacon';

console.log(pizzaParts)

document.addEventListener('click', (e) => console.log('document'));

document.getElementsByTagName('html')[0].addEventListener('click', () => console.log('html'))
