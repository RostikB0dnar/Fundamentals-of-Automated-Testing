describe('DOU Jobs UI Tests', () => {

    // 🔹 Test 1
    it('should open main page', () => {
        cy.visit('https://jobs.dou.ua/')
        cy.title().should('contain', 'DOU')
    })

    // 🔹 Test 2
    it('should show vacancies list', () => {
        cy.visit('https://jobs.dou.ua/')
        cy.get('.vacancy').should('have.length.greaterThan', 0)
    })

    // 🔹 Test 3
    it('should search QA jobs', () => {
        cy.visit('https://jobs.dou.ua/')
        cy.get('input[name="search"]').type('QA{enter}')
        cy.get('.vacancy').should('exist')
    })

})