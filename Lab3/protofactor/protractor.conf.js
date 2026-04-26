exports.config = {
    framework: 'jasmine',
    specs: ['tests/*.spec.js'],
    directConnect: true,
    capabilities: {
        browserName: 'chrome'
    }
};