jQuery(document).ready(function($) {
    // Scroll to the desired section on click
    // Make sure to add the `data-scroll` attribute to your `<a>` tag.
    // Example: 
    // `<a data-scroll href="#my-section">My Section</a>` will scroll to an element with the id of 'my-section'.
    function scrollToSection(event) {
      event.preventDefault();
      var $section = $($(this).attr('href')); 
      var position = $section.offset().top - 80;
      $('html, body').animate({
        scrollTop: position
      }, 300);
    }
    $('[data-scroll]').on('click', scrollToSection);
  }(jQuery));