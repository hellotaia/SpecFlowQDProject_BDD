@qd @elements
Feature: Elements
Elements caregory page
Tests perfomed for: text box, check box, web tables, buttons subpages

Background: Navigate to Elements Categoty page
Given User navigates to 'https://demoqa.com/'
When User choose 'Elements' category
Then 'Elements' page is displayed

## Раздел Text Box
@textbox
Scenario: Verify that all the filled data is equal to displayed
# Заполняем все поля корректными данными. Кликаем по Submit. 
	When User clicks 'Text Box' menu button
	Then 'Text Box' page is displayed
	When User fills the fields with the following values: 
	| Full Name | Email          | Current Address | Permanent Address |
	| test      | test@email.com | test ad         | test permAd       |
	And User clicks 'Submit' button
# Проверяем что все данные в появившейся таблице равны ранее введенным.
	Then the following table is in the response
	| FullName | Email         | Current Address | Permanent Address |
	| test     | test@test.com | test address    | test permAddress  |
