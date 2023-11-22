$(document).ready(function(){
    $('.group-subscription-form-submit').click(function(){
      var requiredFields = $('.group-subscription-required');
      var email = $('input[name="e-mail"]').val();
      var name = $('input[name="name"]').val();
      var groupId = $(this).data('group-id');
  
      var createAccount = false;
      if($('input[name="create-account"]').is(':checked')) {
        createAccount = true;
      }
  
      var requiredValid = [];
  
      $(requiredFields).each(function(){
          var value = $(this).val();
          if ( value === '' ) {
  
            requiredValid.push('false');
            $(this).addClass('input-error');
  
          } else {
  
            $(this).removeClass('input-error');
            requiredValid.push('true');
          }
  
        });
        var notAllRequiredValid = $.inArray('false', requiredValid) !== -1;
  
  
        if( notAllRequiredValid !== true ) {
  
          $.ajax({
            method: 'POST',
            url: jobsdevbg_ajax.ajax_url,
            dataType: 'json',
            data : {
              action: 'user_group_subscription',
              nonce: jobsdevbg_ajax.nonce,
              email: email,
              name: name,
              groupId: groupId,
              createAccount: createAccount
            },
            success : function(response){
              $('.group-subscription-response').html(response);
              $(".group-subscription-title").get(0).scrollIntoView();
            },
            fail : function(error) {
  
            }
          });
        }
    });
  });
  
  function getCookie(cName) {
    const name = cName + "=";
    const cDecoded = decodeURIComponent(document.cookie); //to be careful
    const cArr = cDecoded .split('; ');
    let res;
    cArr.forEach(val => {
      if (val.indexOf(name) === 0) res = val.substring(name.length);
    })
    return res;
  }
  
  function setCookie(cName, cValue, expDays) {
    let date = new Date();
    date.setTime(date.getTime() + (expDays * 24 * 60 * 60 * 1000));
    const expires = "expires=" + date.toUTCString();
    document.cookie = cName + "=" + cValue + "; " + expires + "; path=/; SameSite=Lax";
  }
  
  function delCookie( cName ) {
    setCookie( cName, '', Date.now() );
  }
  
  // Job application popup
  var offcanvasForm = $( '.devbg-offcanvas-form' );
  
  $('.apply-button').on( 'click', function(e) {
    e.preventDefault();
  
    offcanvasForm.addClass( 'open' );
    offcanvasForm.prev( '.curtain' ).addClass( 'open' );
    // offcanvasForm.height( $('body').height() );
    //$('body').css( 'overflow', 'hidden' );
    $('body').addClass( 'form-is-open' );
  });
  
  $('.curtain, .close-form, .close-form-btn' ).on( 'click', function() {
    offcanvasForm.removeClass( 'open' );
    offcanvasForm.prev( '.curtain' ).removeClass('open');
    // $('body').css( 'overflow-x', 'hidden' );
    // $('body').css( 'overflow-y', 'auto' );
    $('body').removeClass( 'form-is-open' );
  });
  
  // Email subscription popup
  // var offcanvasFormSubscribe = $( '.company-subscription-form' );
  //
  // $('.company-subscribe-btn').on( 'click', function() {
  //   offcanvasFormSubscribe.addClass( 'open' );
  //   offcanvasFormSubscribe.prev( '.curtain' ).addClass( 'open' );
  //   // offcanvasForm.height( $('body').height() );
  //   $('body').css( 'overflow', 'hidden' );
  //
  // });
  //
  // closeModalEvent( offcanvasFormSubscribe );
  
  // User login popup
  var offcanvasFormLogin = $( '.subscriber-login-wrapper' );
  
  $('.subscriber-login-btn').on( 'click', function(e) {
    e.preventDefault();
    offcanvasFormLogin.addClass( 'open' );
    offcanvasFormLogin.prev( '.curtain' ).addClass( 'open' );
    offcanvasFormReset.removeClass( 'open' );
    offcanvasFormReset.prev( '.curtain' ).removeClass('open');
    $('body').css( 'overflow', 'hidden' );
  });
  
  closeModalEvent( offcanvasFormLogin );
  
  // Password reset popup
  var offcanvasFormReset = $( '.subscriber-reset-wrapper' );
  // Go to reset pass from login
  $('.subscriber-login-wrapper .btn-reset').on( 'click', function() {
    offcanvasFormReset.addClass( 'open' );
    offcanvasFormReset.prev( '.curtain' ).addClass( 'open' );
    offcanvasFormLogin.removeClass( 'open' );
    offcanvasFormLogin.prev( '.curtain' ).removeClass('open');
    $('body').css( 'overflow', 'hidden' );
  });
  
  closeModalEvent( offcanvasFormReset );
  
  function closeModalEvent( object ) {
    $( '.curtain, .close-form' ).on( 'click', function() {
      object.removeClass( 'open' );
      object.prev( '.curtain' ).removeClass( 'open' );
      $( 'body' ).css( 'overflow-y', 'auto' );
    });
  }
  
  $('.upload-from-profile').on('click', function() {
    $('.show-user-files').slideToggle(400);
    $(this).toggleClass( 'icon-collapse' );
  });
  
  $('.upload-from-pc').on('click', function() {
    var $fileUploadWrapper = $( '.file-upload-box' );
    var $fileUploadResults = $( '.codedropz--results' );
    var $fileUploadInfo = $('.file-upload-info');
    var $uploadArea = $('.codedropz-upload-handler');
  
    $(this).toggleClass( 'icon-collapse' );
  
    // If there are files uploaded
    if ( $fileUploadResults.html() ) {
      // Close a bunch of stuff from inside the container
      $fileUploadInfo.slideToggle(300);
      $uploadArea.slideToggle(300);
    } else {
  
      // This is needed for the cases when the user removed the last file, while the wrapper was closed.
      if ( ! $fileUploadInfo.is(':visible') || ! $uploadArea.is(':visible') ) {
        $fileUploadInfo.show();
        $uploadArea.show();
      }
  
      $fileUploadWrapper.slideToggle(400);
    }
  
  });
  
  $('.remove-file').on( 'click', function() {
    if ( ! $(this).parents( '.codedropz--results' ).html() ) {
      $('.codedropz--results').remove();
    }
  })
  
  // Check / uncheck user uploaded files
  $('.show-user-files input:checkbox').change (
      function() {
          if ($(this).hasClass("file-checked")) {
              $(this).removeAttr("checked").removeClass("file-checked");
              $(this).closest('li').find('.file-box-right .file-box-close').removeClass("show");
              $('.file-box-close').hide();
  
          } else {
              $(this).attr("checked","checked").addClass("file-checked");
              $(this).closest('li').find('.file-box-right .file-box-close').addClass("show");
              $(this).closest('li').addClass('selected-file');
  
              // Remove the file from the list of user files and place it in 'selected files'
              $(this).closest('li').appendTo('.user-chosen-files ul').addClass("chosen");
  
              // Show the text between list of files and chosen files
              if ($('div.user-chosen-files > ul > li').length >= 1 ) {
                  $('div.user-chosen-files').find('.chosen-file-title').addClass("show");
              }
  
              // The close functionality
              $('.file-box-close.show').on('click', function() {
                  $(this).closest('li').find('input:checkbox').removeAttr("checked").removeClass("file-checked").show().prop("checked", false);
                  $(this).removeClass("show");
                  $(this).closest('li').removeClass('selected-file');
  
              });
  
              $('.file-box.chosen .file-box-close.show').on('click', function() {
                  // Move the selected file back to the list of user files
                  $(this).closest('li.chosen').appendTo('.show-user-files ul').removeClass("chosen");
  
                  // Hide the text between list of files and chosen files
                  if ($('div.user-chosen-files > ul > li').length < 1) {
                      $('div.user-chosen-files').find('.chosen-file-title.show').removeClass("show");
                  }
              });
          }
  
      }
  );
  
  
  
  $(document).keydown(function(e) {
    // ESCAPE key pressed
    if (e.keyCode === 27) {
      offcanvasFormSubscribe.removeClass( 'open' );
      offcanvasFormSubscribe.prev( '.curtain' ).removeClass( 'open' );
      $( 'body' ).css( 'overflow-x', 'hidden' );
      $( 'body' ).css( 'overflow-y', 'auto' );
    }
  });
  
  
  $(document).ready( function() {
  
    // show tooltip on application form
    $('.quiz-wrapper').hover(
        function () {
          $('.short-question, .robot-check').addClass('open').closest('div').find('.form-tooltip').addClass('visible');
        },
        function () {
          $('.short-question, .robot-check').removeClass('open').closest('div').find('.form-tooltip').removeClass('visible');
        }
    );
  
    //Disable "pick personal files" button in application form if no files are present
    if ( $('.show-user-files ul > li').length < 1 ) {
      $('.upload-from-profile').addClass("disabled");
      $('.additional-text').show();
    }
  
    $( '.company-gallery-inner' ).each( function() {
      var $gallery = $(this);
  
      var getItems = function() {
        var items = [];
  
        $gallery.find('img').each( function() {
          var item = {
            msrc: $(this).attr('src'),
            src: $(this).data('src'),
            w: $(this).data('w'),
            h: $(this).data('h'),
          };
  
          items.push(item);
        });
  
        return items;
      }
  
      var items = getItems();
  
      $pswp = $('.pswp')[0];
  
      $gallery.on( 'click', 'img', function(e) {
        e.preventDefault();
  
        var $index = $(this).parent().index();
        var $selectedImg = $(this);
  
        if ( $(this).parent().hasClass( 'image-wide' ) ) {
          $index += 3;
        }
  
        var options = {
          index: $index,
          bgOpacity: 0.7,
          showHideOpacity: true,
          preload: [1, 1],
          getThumbBoundsFn: function(index) {
            var coords = { x: $selectedImg.position().left, y: $selectedImg.position().top, w: $selectedImg.width() };
            return coords;
          },
        };
  
        var lightBox = new PhotoSwipe( $pswp, PhotoSwipeUI_Default, items, options );
        lightBox.init();
      })
    });
  
    /* Clicks on the hidden "going" button in order to get to the second step of ticket reservation */
    if ( $('.tribe-events-page-template').length === 1 ) {
      let container = $(".tribe-tickets__rsvp-wrapper");
      if ( container.length === 1 ) {
        let letRsvpId = container.data('rsvp-id');
        let data = {
          action: 'tribe_tickets_rsvp_handle',
          ticket_id: letRsvpId,
          step: 'going',
        };
        tribe.tickets.rsvp.manager.request( data, container );
      }
    }
  
  });
  
  $('.gallery-all').on( 'click', function() {
    var images = $(this).data('images');
    var pswp = $('.pswp')[0];
  
    var options = {
      index: 5,
      bgOpacity: 0.7,
      showHideOpacity: true,
      preload: [1, 2],
    };
  
    var lightBox = new PhotoSwipe( pswp, PhotoSwipeUI_Default, images, options );
    lightBox.init();
  });
  
  $('.section-collapse').on('click', function() {
    $(this).siblings('.child-term, .mt-25').toggle(200);
    $(this).toggleClass('collapsed');
  })
  
  // Make sure the mobile menu is closed by default on pageload.
  $(document).ready( function() {
    let mobileToggle = document.getElementById("mobile-toggle" );
    if ( mobileToggle ) {
      mobileToggle.checked = false;
    }
  })
  
  $('#mobile-toggle').on( 'click', function() {
    if ( document.getElementById('mobile-toggle').checked ) {
      $('body').css( 'overflow-y', 'hidden' );
    } else {
      $('body').css( 'overflow-y', 'auto' );
    }
  });
  
  // Mobile menu submenu toggle
  $('.mobile-menu .menu-item-has-children > a').on( 'click', function(e) {
    e.preventDefault();
  
    $(this).parent().toggleClass('open');
    $(this).siblings('.sub-menu').toggleClass('open');
  });
  
  /* Report job listing */
  $('#toggle-report-form').on('click', function() {
    $('.report-form-wrapper').slideDown();
    $('.single_job_listing .job-listing-meta').slideUp();
  });
  
  $('.report-form-wrapper .close').on('click', function() {
    $('.report-form-wrapper').slideUp();
    $('.single_job_listing .job-listing-meta').slideDown();
  });
  /* END Report job listing */
  
  /* Company employee testimonials */
  $(document).ready(function () {
    if($('body').is('.single-company_listings')){
      $('.employee-testimonials').slick({
        dots: true,
        infinite: true,
        arrows: false,
      });
    }
  
  });
  /* END Company employee testimonials */
  
  $(".company-scroll-to-job").click(function() {
      $('html, body').animate({
          scrollTop: $("#jobs").offset().top
      }, 1000);
  });
  
  /* Slide sidebar - page companies */
  
  var $menuContainer = $('.left-sidebar-navigation');
  if ($menuContainer.length) {
  
    $(document).on("scroll", onScroll);
  
    //smoothscroll
    $('.company-sidebar a[href^="#"]').on('click', function (e) {
      e.preventDefault();
      $(document).off("scroll");
  
      var target = this.hash,
          menu = target;
      $target = $(target);
  
      $('html, body').stop().animate({
        'scrollTop': $target.offset().top + 2
      }, 1000, 'swing', function () {
        window.location.hash = target;
        $(document).on("scroll", onScroll);
      });
    });
  
    function onScroll(event) {
      var scrollPos = $(document).scrollTop() + 100;
      var jobsElement = document.querySelector('#jobs');
      $('.sidebar-nav-holder a.sidebar-nav-item').each(function () {
  
        var currLink = $(this);
        var refElement = $(currLink.attr("href"));
  
        if (currLink && refElement.position().top <= scrollPos && refElement.position().top + refElement.height() > scrollPos) {
  
          if (isInViewport(jobsElement)) {
            $('.sidebar-nav-holder a.sidebar-nav-item').removeClass("w--current");
            $('.sidebar-nav-holder a.jobs').addClass("w--current");
          } else {
            $('.sidebar-nav-holder a.sidebar-nav-item').removeClass("w--current");
            $('.sidebar-nav-holder a.first-item').removeClass("first-item");
            currLink.addClass("w--current");
          }
        }
  
        if ($(".sidebar-nav-holder a.jobs").hasClass("w--current")) {
          $("#sidebar-nav-list a.first-item").removeClass("first-item");
        }
      });
    }
  
  // Check if section is in viewport - used for #jobs section active marker
    function isInViewport(element) {
      const rect = element.getBoundingClientRect();
      return (
          rect.top >= 0 && rect.left >= 0 &&
          rect.bottom <= (window.innerHeight || document.documentElement.clientHeight) &&
          rect.right <= (window.innerWidth || document.documentElement.clientWidth) &&
          rect.top < window.innerHeight / 2
      );
    }
  }
  /* END Slide sidebar - page companies */
  
  /* Report listing form effects */
  $('#toggle-report-form').on('click', function() {
    $('.report-form-wrapper').slideDown();
    $('.single_job_listing .job-listing-meta').slideUp();
  });
  
  $('.report-form-wrapper .close').on('click', function() {
    $('.report-form-wrapper').slideUp();
    $('.single_job_listing .job-listing-meta').slideDown();
  });
  
  /* Click function of fileupload button when text field is clicked*/
  $("#uploadtextfield").click(function() {
    $("#fileuploadfield").click();
  });
  
  /* Click function of fileupload button when browse button is clicked*/
  $("#uploadbrowsebutton").click(function() {
    $("#fileuploadfield").click();
  });
  
  /* To bring the selected file value in text field */
  $("#fileuploadfield").change(function () {
    var path = $(this).val();
    var filename = path.replace('C:\\fakepath\\', '');
    $("#uploadtextfield").val(filename);
  });
  
  /* miniboard open subscription box */
  $(".open-subscribe").click( function(e) {
    e.preventDefault();
    $('.board-subscription-status').show();
    $('.curtain').first().addClass('open');
  })
  
  $('.close-subscription-popup').click( function(e) {
    e.preventDefault();
    $('.board-subscription-status').hide();
    $('.curtain').removeClass('open');
  })
  
  /* This replaces the generic label, for the group-subscribe radio field,
   * inside the registration form in single events, with a custom label,
   * tailored for the current user group.
   */
  $('.tribe-tickets__rsvp-wrapper').resize( function() {
    var radioLabel = $('.user-group-radio-label');
    if ( radioLabel.length ) {
      var newLabel = radioLabel.html();
  
      $('.group-subscribe-radio-label').html( newLabel );
    }
  });
  
  /* Homepage CTA button */
  
  $("#homepage-cta-scroll").click(function() {
    $([document.documentElement, document.body]).animate({
      scrollTop: $("#section-category-block").offset().top
    }, 1300);
  });
  
  /* END Homepage CTA button */
  
  /* COMPONENT - subscription plan */
  $( '.quantity-select:not(.popup-quantity)' ).on( 'change', function() {
    var selectedQuantity = $( this ).val();
    var parentContainer = $( this ).parents( '.subscription-plan' );
    var singularPrice = parentContainer.find('.singular-price').data('singular-price');
    var calculatedPrice = selectedQuantity * singularPrice;
  
    parentContainer.find('.price').html( calculatedPrice + 'лв.' );
    parentContainer.find('.price').data('price', calculatedPrice );
  });
  
  //Disable main button if user is not agreed with the term of service
  $( '.plan-config .terms-of-service-checkbox' ).on( 'change', function() {
    const $main_button = $( this ).parents( '.subscription-plan' ).find( '.main-button' );
  
    if ( $( this ).is( ':checked' ) ) {
      $main_button.removeClass( 'disabled' );
    } else {
      $main_button.addClass( 'disabled' );
    }
  } );
  /* END component - subscription plan */
  
  /* Employer registration */
  
  // Validate the registration form
  $('#employer-registration-validate').on( 'click', function(e) {
    e.preventDefault();
  
    var employer_email = $('input[name="employer_email"]').val();
    var employer_phone = $('input[name="employer_phone"]').val();
    var employer_lang = $('select[name="employer_lang"]').val();
    var employer_lang_label = $('select[name="employer_lang"] option:selected').text()
    var entity_name = $('input[name="entity_name"]').val();
    var ceo_name = $('input[name="ceo_name"]').val();
    var entity_EIK = $('input[name="entity_EIK"]').val();
    var entity_address = $('input[name="entity_address"]').val();
    var entity_invoice_email = $('input[name="entity_invoice_email"]').val();
    var plan_name = $('input[name="plan_name"]').val();
    var selected_credits = $('input[name="selected_credits"]').val();
  
    //Reset the current tab and tab content, so we have a clean slate
    $( '.registration-tab' ).removeClass('active');
    $( '.tab-content' ).removeClass('active');
    jQuery('.company-signup-fail').remove();
  
    // Render the loader
    $('.employer-registration-content-wrap').addClass( 'loading' );
  
    $.ajax({
      method: 'POST',
      url: jobsdevbg_ajax.ajax_url,
      dataType: 'json',
      data : {
        action: 'validate_company_signup',
        nonce: jobsdevbg_ajax.nonce,
        employer_email: employer_email,
        employer_phone: employer_phone,
        employer_lang: employer_lang,
        entity_name: entity_name,
        ceo_name: ceo_name,
        entity_EIK: entity_EIK,
        entity_address: entity_address,
        entity_invoice_email: entity_invoice_email,
        plan_name: plan_name,
        selected_credits: selected_credits
      },
      success : function(response){
  
        // Remove the loader
        $('.employer-registration-content-wrap').removeClass('loading');
  
        if( 'OK' === response ) {
          // Fill in the fields in tab 3, before switching to it
          $('input[name="final_employer_email"]').val(employer_email);
          $('input[name="final_employer_phone"]').val(employer_phone);
          $('input[name="final_employer_lang"]').val(employer_lang_label);
          $('input[name="final_entity_name"]').val(entity_name);
          $('input[name="final_ceo_name"]').val(ceo_name);
          $('input[name="final_entity_EIK"]').val(entity_EIK);
          $('input[name="final_entity_address"]').val(entity_address);
          $('input[name="final_entity_invoice_email"]').val(entity_invoice_email);
  
          // Set tab 3 as the active tab.
          employerRegGotoPage(3);
        } else {
          employerRegGotoPage(2);
          $('.employer-registration-form').prepend(response);
        }
      }
    });
  })
  
  $('#employer-registration-submit').on( 'click', function() {
    var employer_email = $('input[name="final_employer_email"]').val();
    var employer_phone = $('input[name="final_employer_phone"]').val();
    var employer_lang = $('select[name="employer_lang"]').val(); //Avoid unnecessary data transfer?
    var entity_name = $('input[name="final_entity_name"]').val();
    var ceo_name = $('input[name="final_ceo_name"]').val();
    var entity_EIK = $('input[name="final_entity_EIK"]').val();
    var entity_address = $('input[name="final_entity_address"]').val();
    var entity_invoice_email = $('input[name="final_entity_invoice_email"]').val();
    var plan_name = $('input[name="plan_name"]').val();
    var selected_credits = $('input[name="selected_credits"]').val();
  
    jQuery('.company-signup-fail').remove();
    // Render the loader
    $('.employer-registration-content-wrap').addClass( 'loading' );
  
    if( $('input[name="TOS"]').is(':checked') ) {
      //Reset the current tab and tab content, so we have a clean slate
      $( '.registration-tab' ).removeClass('active');
      $( '.tab-content' ).removeClass('active');
  
      $.ajax({
        method: 'POST',
        url: jobsdevbg_ajax.ajax_url,
        dataType: 'json',
        data : {
          action: 'process_company_signup',
          nonce: jobsdevbg_ajax.nonce,
          employer_email: employer_email,
          employer_phone: employer_phone,
          employer_lang: employer_lang,
          entity_name: entity_name,
          ceo_name: ceo_name,
          entity_EIK: entity_EIK,
          entity_address: entity_address,
          entity_invoice_email: entity_invoice_email,
          plan_name: plan_name,
          selected_credits: selected_credits
        },
        success : function(response){
  
          // Remove the loader
          $('.employer-registration-content-wrap').removeClass('loading');
  
          if( 'OK' === response ) {
            window.location.replace(jobsdevbg_ajax.company_signup_complete_page);
          } else {
            employerRegGotoPage(2);
            $('.employer-registration-form').prepend(response);
          }
        }
      });
    } else {
      jQuery('.terms-checkbox-wrap').append('<span class="company-signup-fail">' + jobsdevbg_ajax.txt_accept_terms + '</span>');
    }
  
  
  });
  
  $('.registration-select-plan').on( 'click', function() {
    var planName = $( this ).data( 'plan-name' );
    var $planContainer = $( this ).parents( '.subscription-plan' );
    var creditsCount = $planContainer.find( '.quantity-select' ).val();
    var totalPrice = parseInt( $planContainer.find( '.price' ).data( 'price' ) ) || 0;
    //Plan 20+ is now hidden (DVB-200), so this might be deleted in future
    if ( '20+' == planName ) {
      totalPrice = '4000+';
      creditsCount += '+';
    }
  
    $( '.step-3' ).removeClass( 'is-single-credit' );
    if ( ! planName ) {
      $( '.step-3' ).addClass( 'is-single-credit' );
      planName = 'singleCredit'
      creditsCount = 1;
    }
  
    $( '#plan_name' ).val( planName );
    $( '#selected_credits' ).val( creditsCount );
  
    $( '.final-price' ).html( totalPrice + 'лв' );
    $('#final-credit-count').html( creditsCount );
  
    employerRegGotoPage(2);
  });
  
  $(".step-back").on( 'click', function() {
    var targetPage = $( this ).data( 'step' );
  
    employerRegGotoPage(targetPage);
  });
  
  function employerRegGotoPage( page ) {
    //Reset the current tab and tab content, so we have a clean slate
    $( '.registration-tab' ).removeClass('active');
    $( '.tab-content' ).removeClass('active');
  
    $( '.registration-tab[data-tab='+ page +']' ).addClass('active');
    $( '.tab-content[data-tab='+ page +']' ).addClass('active');
  }
  /* END employer registration */
  
  $( '.premium-always-on-dialog-confirm' ).on( 'click', function(e) {
    //TODO export this to a separate file for employers only
    e.preventDefault();
    var targetId = $( this ).data( 'target-id' );
    var isAlwaysOn = $( e.currentTarget ).closest( '.component-popup.premium-always-on-popup' ).find( 'input#premium-job-always-on' ).is( ':checked' ) ? 1 : 0;
    
    transformButton( this, 'disabled', jobsdevbg_ajax.txt_please_wait );
  
    $.ajax({
      method: 'POST',
      url: jobsdevbg_ajax.ajax_url,
      dataType: 'json',
      data : {
        action: 'employer_spend_credits',
        nonce: jobsdevbg_ajax.nonce,
        job_id: targetId,
        always_on: isAlwaysOn,
      },
      success: function( response ) {
        console.log( response );
        if ( response.success ) {
          // reload the page and add the param that will load our success popup
          if ( response.data.job_id ) { // The job has a new ID now
            window.location.search = '?id='+ response.data.job_id +'&promoted=true&always_on=' + isAlwaysOn ;
          } else {
            window.location.search = '?id='+ targetId +'&promoted=true&always_on=' + isAlwaysOn ;
          }
        } else {
          window.location.search = '?id='+ targetId +'&promoted=false&always_on=' + isAlwaysOn ;
        }
      }
    });
  });
  
  $( '.open-excerpt-dialog' ).on( 'click', function() {
    openPopupDialog( 'excerpt-dialog' );
  });
  
  $( '.edit-excerpt' ).on( 'click', function() {
    var targetId = $( this ).data( 'target-id' );
  
    window.location.search = '?id='+ targetId +'&excerpt-edit=true';
  });
  
  // fires upon clicking the 'add excerpt' button after promoting a job.
  $( '.add-excerpt' ).on( 'click', function(e) {
    e.preventDefault();
  
    var userExcerpt = $( '#excerpt-field' ).val();
    var jobId = $( this ).data( 'target-id' );
  
    transformButton( this, 'disabled', jobsdevbg_ajax.txt_please_wait );
  
    $.ajax({
      method: 'POST',
      url: jobsdevbg_ajax.ajax_url,
      dataType: 'json',
      data : {
        action: 'employer_set_job_excerpt',
        nonce: jobsdevbg_ajax.nonce,
        jobId: jobId,
        userExcerpt: userExcerpt,
      },
      success: function(response) {
        console.log( response );
        // Reload the page, removing the get params.
        window.location = window.location.pathname;
      }
    });
  
  })
  /* END Popup dialog component open/close */
  
  /* Employer panel - plans */
  $( '.plan-details-link' ).on( 'click', function(e) {
    e.preventDefault();
  
    var targetPopup = $( this ).data( 'popup' );
  
    // add a 'popup-open' class to the parent container, so we don't have conflicting z-indexes with the other cols.
    $( this ).parents( '.subscription-plan' ).addClass( 'popup-open' );
    openPopupDialog( targetPopup );
  });
  
  $( '.switch-plan' ).on( 'click', function(e) {
    e.preventDefault();
    if ( $( this ).hasClass( 'disabled' ) ) {
      return;
    }
  
    var parentPopup = $( this ).parents( '.popup-dialog' );
    var entityId = $( this ).data( 'cid' );
    var selectedCount = parentPopup.find( '.quantity-select' ).val();
    var tosChecked = parentPopup.find( '.terms-of-service-checkbox' ).is( ':checked' ) ? 1 : 0;
    var planName = $( this ).data( 'plan-name' );
    var employerEmail = '';
    var employerPhone = '';
    var originalLabel = $( this ).html();
    var _this = this;
  
    //Plan 20+ is now hidden (DVB-200), so this might be deleted in future
    //For  single credit and 20+plans we collect some data
    if ( ! planName || '20+' == planName ) {
      employerEmail = parentPopup.find( '#employer_email' ).val();
      employerPhone = parentPopup.find( '#employer_phone' ).val();
  
      if ( ! employerEmail && ! employerPhone ) {
        alert( jobsdevbg_ajax.txt_please_fill );
        return;
      } else if ( employerEmail && ! isEmail( employerEmail ) ) {
        alert( jobsdevbg_ajax.txt_invalid_email_field );
        return;
      }
  
    }
  
    transformButton( this, 'disabled', jobsdevbg_ajax.txt_please_wait );
    
    $.ajax({
      method: 'POST',
      url: jobsdevbg_ajax.ajax_url,
      dataType: 'json',
      data : {
        action: 'employer_change_plan',
        nonce: jobsdevbg_ajax.nonce,
        entityId: entityId,
        selectedCount: selectedCount,
        tosChecked: tosChecked,
        planName: planName,
        employerEmail: employerEmail,
        employerPhone: employerPhone,
      },
      success: function(response) {
        if ( 'Success' === response ) {
          window.location.search = '?plan_changed=true&plan_name=' + encodeURIComponent( planName );
        } else {
          alert( jobsdevbg_ajax.txt_request_error );
          $( _this ).removeClass( 'disabled' );
          $( _this ).html( originalLabel );
        }
      }
    });
  })
  
  $( '.plans-unsubscribe' ).on( 'click', function(e) {
    e.preventDefault();
  
    openPopupDialog( 'cancel-plan-dialog' );
  })
  
  $( '.cancel-plan-confirm' ).on( 'click', function() {
  
    if ( $( this ).hasClass( 'disabled' ) ) {
      return;
    }
    transformButton( this, 'disabled', jobsdevbg_ajax.txt_please_wait );
    
    $.ajax({
      method: 'POST',
      url: jobsdevbg_ajax.ajax_url,
      dataType: 'json',
      data : {
        action: 'employer_cancel_plan',
        nonce: jobsdevbg_ajax.nonce,
      },
      success: function(response) {
        openPopupDialog( 'plan-cancelled-successfully' );
      }
    });
  });
  
  // calculates the pricing, on quantity change in the plan config popup
  $( '.config-quantity' ).on( 'change', function() {
    var selectedQuantity = $( this ).val();
    var popupWrap = $( this ).parents( '.plan-config' );
    var singularPrice = $( this ).data( 'singular-price' );
    var calculatedPrice = selectedQuantity * singularPrice;
  
    popupWrap.find('.config-price').html( calculatedPrice + jobsdevbg_ajax.txt_currency );
    popupWrap.find('.config-price').data('price', calculatedPrice );
  })
  
  /* END Employer panel - plans */
  
  /* Employer Panel - Invoice settings */
  $( '#save-invoice-data' ).on( 'click', function(e) {
    e.preventDefault();
  
    var _this = this;
    var hasErrors = false;
    var buttonLabel = $(this).html();
  
    var fields = {
      invoiceCompanyName: $( '#invoice_company_name' ),
      invoiceCity: $( '#invoice_city' ),
      invoiceAddress: $( '#invoice_address' ),
      invoiceCeo: $( '#invoice_ceo' ),
      invoiceEik: $( '#invoice_eik' ),
      invoiceVatNumber: $( '#invoice_vat_number' ),
    }
  
    $('.input-error-hint').remove();
    $('.devbg-input-error').removeClass( 'devbg-input-error' );
  
    for ( var field in fields ) {
  
      if ( 0 === fields[field].val().length ) {
        var emptyError = '<span class="input-error-hint"> ' + jobsdevbg_ajax.txt_no_empty_field + ' </span>';
        fields[field].addClass( 'devbg-input-error' );
        $( emptyError ).insertAfter( fields[field] );
  
        hasErrors = true;
      }
  
    }
  
    if ( ! hasErrors ) {
      transformButton( this, 'disabled', jobsdevbg_ajax.txt_please_wait );
  
      $.ajax({
        method: 'POST',
        url: jobsdevbg_ajax.ajax_url,
        dataType: 'json',
        data : {
          action: 'employer_save_invoice_data',
          invoiceCompanyName: fields.invoiceCompanyName.val(),
          invoiceCity: fields.invoiceCity.val(),
          invoiceAddress: fields.invoiceAddress.val(),
          invoiceCeo: fields.invoiceCeo.val(),
          invoiceEik: fields.invoiceEik.val(),
          invoiceVatNumber: fields.invoiceVatNumber.val(),
        },
        success: function(response) {
          $( _this ).removeClass( 'disabled' );
          $( _this ).html( jobsdevbg_ajax.txt_edit );
          console.log( response );
          switch ( response ) {
            case 'success' :
              transformButton( _this, 'success', jobsdevbg_ajax.txt_saved, 3000 );
              console.log( 'Invoice data saved.' );
              break;
            case 'no-change' :
              transformButton( _this, 'success', jobsdevbg_ajax.txt_saved, 3000 );
              console.log( 'No change.' );
              break;
            case 'fail' :
              transformButton( _this, 'warning', jobsdevbg_ajax.txt_save_failed );
              console.log( 'Post meta update failed.' );
              break;
            default :
              transformButton( _this, 'success', jobsdevbg_ajax.txt_ready, 3000 );
          }
  
          console.log( response );
  
        }
      });
  
    } else {
      transformButton( _this, 'warning', jobsdevbg_ajax.txt_field_error, 3000 );
    }
  
  });
  
  /* END Employer pane - invoice settings */
  
  /* Employer mobile */
  // mobile toggle for the employer navigation
  $('#employer-nav-toggle').on( 'click', function() {
    $( this ).toggleClass( 'open' );
    $( '.nav-panel-vertical').toggleClass('open');
    $('body').toggleClass('disable-scroll');
    $( '.employer-panel-wrap' ).toggleClass('open');
  });
  /* END Employer mobile */
  
  // Transforms a button to a special one
  function transformButton( button, className, label, timeout ) {
  
    var originalLabel = $( button ).html();
  
    $( button ).addClass( className );
    $( button ).html( label );
  
    if ( timeout ) {
  
      setTimeout( function() {
        $( button ).removeClass( className );
        $( button ).html( originalLabel );
      }, timeout );
  
    }
  
  }