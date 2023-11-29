// This file is cobbled together very quickly, it could use some optimization
$(document).ready(function() {
    // Backup the full placeholder in an additional attribute
    let homepageHeader = $('.homepage-header');
    let searchInput = homepageHeader.find('.search-input');
    searchInput.attr('data-full-placeholder', searchInput.attr('placeholder'));

    maybeTruncatePlaceholder();
});

$(window).resize(() => maybeTruncatePlaceholder());

// Truncate the searchbar placeholder on small screens.
function maybeTruncatePlaceholder() {
    let homepageHeader = $('.homepage-header');
    let width = $(window).width();
    let searchInput = homepageHeader.find('.search-input');
    let placeholder = searchInput.attr('placeholder');

    if (width <= 950) {
        searchInput.attr('placeholder', placeholder.slice(0, 21));
    } else {
        searchInput.attr('placeholder', searchInput.attr('data-full-placeholder'));
    }

}