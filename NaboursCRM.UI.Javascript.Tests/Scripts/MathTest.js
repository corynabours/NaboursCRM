/// <reference path="JavaScriptUnitTestFramework.js"/>
function testAddNumbers() {
    // Act     
    var result = addNumbers(1, 3);
    // Assert     
    assert.areEqual(4, result, "addNumbers did not return right value!");
}
