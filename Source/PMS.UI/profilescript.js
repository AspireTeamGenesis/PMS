let collapsable = document.querySelectorAll(".collapsable");
let collapse = document.querySelectorAll(".collapse");

collapse.forEach(function (item, index) {
    item.addEventListener("click", ()=>{
        // collapsable.forEach((divItem)=>{
        //     divItem.classList.remove("collapsed");
        // });

        if(collapsable[index].classList.contains("collapsable")){
            collapsable[index].classList.add("collapsed");
            collapsable[index].classList.remove("collapsable"); 
        } 
        
        else if(collapsable[index].classList.contains("collapsed")){
            collapsable[index].classList.remove("collapsed")
            collapsable[index].classList.add("collapsable");
        }
    });
});