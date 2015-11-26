'use strict';

function addKeyValuePair() {

    var table = $('#keyValuePairTable');
    var row = $('<div class="input-group">'),
        keyInput = $('<input type="text" name="key[]" placeholder="key" class="form-control">').appendTo(row),
        addon = $('<span class="input-group-addon">=</span>').appendTo(row),
        valueInput = $('<input type="text" name="value[]" placeholder="value" class="form-control">').appendTo(row);
    table.append(row);

    return false;

}