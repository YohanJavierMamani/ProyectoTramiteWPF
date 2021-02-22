    var count = 20; // Timer
    var redirect = "/"; // Target URL

  function countDown() {
    var timer = document.getElementById("timer"); // Timer ID
    if (count > 0) {
        count--;
        timer.innerHTML = "Esta página se rediccionará en " + count + " segundos."; // Timer Message
      setTimeout("countDown()", 1000);
    }
  }
