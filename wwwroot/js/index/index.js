const animate = document.querySelector(".animate");

function checkScroll() {
  let scrollPosition = window.innerHeight + window.scrollY;
  if (animate.offsetTop + animate.offsetHeight <= scrollPosition) {
    animate.classList.add("active");
  }
}

window.addEventListener("scroll", checkScroll);

// TWIST TEXT!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
window.onscroll = function () {
  scrollTwist();
};

function scrollTwist() {
  var p1 = document.getElementById("p1");
  var p2 = document.getElementById("p2");
  var p3 = document.getElementById("p3");
  var p4 = document.getElementById("p4");
  var p5 = document.getElementById("p5");

  var rotateX = window.scrollY * 0.1;
  var skewY = (window.scrollY / 5) * 0;

  if (window.scrollY > 10) {
    p1.style.transform =
      "rotateY(" +
      window.scrollY / 5 +
      "deg) rotateX(" +
      rotateX +
      "deg) skew(0deg, " +
      skewY +
      "deg)";
    p1.style.opacity = 1;
  } else {
    p1.style.opacity = 0;
  }

  if (window.scrollY > 50) {
    p2.style.transform =
      "rotateY(" +
      window.scrollY / 6 +
      "deg) rotateX(" +
      rotateX +
      "deg) skew(0deg, " +
      skewY +
      "deg)";
    p2.style.opacity = 1;
  } else {
    p2.style.opacity = 0;
  }

  if (window.scrollY > 90) {
    p3.style.transform =
      "rotateY(" +
      window.scrollY / 7 +
      "deg) rotateX(" +
      rotateX +
      "deg) skew(0deg, " +
      skewY +
      "deg)";
    p3.style.opacity = 1;
  } else {
    p3.style.opacity = 0;
  }

  if (window.scrollY > 130) {
    p4.style.transform =
      "rotateY(" +
      window.scrollY / 8 +
      "deg) rotateX(" +
      rotateX +
      "deg) skew(0deg, " +
      skewY +
      "deg)";
    p4.style.opacity = 1;
  } else {
    p4.style.opacity = 0;
  }

  if (window.scrollY > 150) {
    p5.style.transform =
      "rotateY(" +
      window.scrollY / 9 +
      "deg) rotateX(" +
      rotateX +
      "deg) skew(0deg, " +
      skewY +
      "deg)";
    p5.style.opacity = 1;
  } else {
    p5.style.opacity = 0;
  }
}

SLIDER;
