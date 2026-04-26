describe('DOU Jobs UI Tests', function() {

    // 🔹 Test 1
    it('should open homepage', async function() {
        await browser.get('https://jobs.dou.ua/')
        expect(await browser.getTitle()).toContain('DOU')
    })

    // 🔹 Test 2
    it('should display vacancies', async function() {
        const vacancies = element.all(by.css('.vacancy'))
        expect(await vacancies.count()).toBeGreaterThan(0)
    })

    // 🔹 Test 3
    it('should search QA jobs', async function() {
        await browser.get('https://jobs.dou.ua/')

        await element(by.css('input[name="search"]'))
            .sendKeys('QA', protractor.Key.ENTER)

        const results = element.all(by.css('.vacancy'))
        expect(await results.count()).toBeGreaterThan(0)
    })

})