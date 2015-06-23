function checkBrowser() {
    'use strict';

    var browser = window.navigator.appCodeName,
        isMozilla = (browser === 'Mozilla');

    if (isMozilla) {
        alert('Yes, it\'s Mozilla');
    } else {
        alert('No, it\'s not');
    }
}