const animate = document.querySelector('.animate');

function checkScroll() {
  let scrollPosition = window.innerHeight + window.scrollY;
  if (animate.offsetTop + animate.offsetHeight <= scrollPosition) {
    animate.classList.add('active');
  }
}

window.addEventListener('scroll', checkScroll);




// COOKIE POPUP!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
$(document).ready(function(){
	// show automatically after 1s
	setTimeout(showModal,1000);
	$("#closeBtn").click(function(){
		$("#myModal").hide()
	})
	function showModal(){
		// get value from localStorage
		var is_modal_show = sessionStorage.getItem('alreadyShow');
		if(is_modal_show != 'alredy shown'){
			$("#myModal").show()
			sessionStorage.setItem('alreadyShow','alredy shown');
		}else{
			console.log(is_modal_show);
		}
	}
})


// SLIDER
