const AjaxUrl = '/Home/GetSimilarName'
const userName = document.querySelector('#userName')
const suggestionList = document.querySelector('#suggestedList')

if (userName) {
    userName.addEventListener('keyup', () => {
        const name = userName.value
        suggestionList.innerHTML = '';
        fetch(`${AjaxUrl}?name=${name}`).then((res) => {

            res.json().then((response) => {
                suggestionList.innerHTML = '';
                response.forEach((item) => {
                    suggestionList.innerHTML += `<li class='cursor-pointer text-decoration-none'> ${item.name}</li>`
                })

                suggestionList.querySelectorAll('li').forEach((option) => {
                    option.addEventListener('click', () => {
                        userName.value = option.innerHTML;
                        suggestionList.innerHTML = '';
                    })
                })
            })
        }).catch((err) => {
            console.log(err)
        })
    })
}