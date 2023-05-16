@qd @forms
Feature: Forms
Forms caregory page
Tests perfomed for Practice Form subpage

Background: Navigate to Forms Categoty page
Given User navigates to 'https://demoqa.com/'
When User choose 'Forms' category
Then 'Forms' page is displayed

@practiceForm
Scenario: Paractice Form - 
When User clicks 'Practice Form' menu button
Then 'Practice Form' page is displayed
#Заполнить все текстовые поля произвольными данными.  
When User fills the text fields with the following values: 
| key             | value       |
| First Name      | Elon        |
| Last Name       | Musk        |
| Email           | i@test.com  |
| Mobile Number   | 1285000000  |
| Current Address | Oak str, 12 |
# Дальше для Gender выбрать Female,
And User selects 'Female' gender radiobutton
#в Date of Birth ввести любую другую корректную дату,
And User fills '21 March 1976' date of birth
# в Subjects добавить Physics и Maths, 
And User fills 'Physics' subject
And User fills 'Maths' subject
# в Hobbies выбрать Reading и Music, 
And User selects 'Reading' hobbie value
And User selects 'Music' hobbie value
#и нажать Enter. 
 And User press 'Enter' button
# кликнуть по дропдауну State and City и выбрать "Uttar Pradesh", 
And User selects 'Uttar Pradesh' in 'State' dropdown
# ввести в Select City "Merrut"
And User selects 'Merrut' in 'City' dropdown
#Загружает файл
And User uploads picture file
#Кликнуть по Submit. 
And User clicks 'Submit' button
# Проверить что в появившейся модалке все отображенные данные соответствуют тому, что вы вводили.
Then 'Thanks for submitting the form' modal is displayed
Then User verifies that following values are displayed in the modal
| Label          | Value                |
| Student Name   | Elon Musk            |
| Student Email  | i@test.com           |
| Gender         | Female               |
| Mobile         | 1285000000           |
| Date of Birth  | 21 March,1976        |
| Subjects       | Physics, Maths       |
| Hobbies        | Reading, Music       |
| Picture        | 1.png                |
| Address        | Oak str, 12          |
| State and City | Uttar Pradesh Merrut |