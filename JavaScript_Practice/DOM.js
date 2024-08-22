let prepend = document.querySelector('.prepend')
let append = document.querySelector('.append')
let removeFirst = document.querySelector('.removeFirst')
let removeLast = document.querySelector('.removeLast')
let list = document.querySelector('ul')

function createLi () {
  let li = document.createElement('li')
  li.innerHTML = 'Hello again, world!'
  return li
}

// Prepend
prepend.addEventListener('click', e => list.prepend(createLi()))

// Append
append.addEventListener('click', e => list.append(createLi()))

// Remove First
removeFirst.addEventListener('click', e => {
  if (list.children.length) {
    let firstNode = list.children[0]
    list.removeChild(firstNode)
  }
})    

// Remove Last
removeLast.addEventListener('click', e => {
  if (list.children.length) {
    let lastNode = list.children[list.children.length - 1]
    console.log(lastNode)
    list.removeChild(lastNode)
  }
})   
