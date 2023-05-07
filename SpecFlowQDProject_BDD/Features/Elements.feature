@qd @elements
Feature: Elements
Elements caregory page
Tests perfomed for: text box, check box, web tables, buttons subpages

Background: Navigate to Elements Categoty page
Given User navigates to 'https://demoqa.com/'

Scenario: Verify Elements Page title
Given User choose 'Elements' category
Then 'Elements' page is displayed

## Раздел Text Box
@textbox
Scenario: Verify that all the filled data is equal to displayed
# Заполняем все поля корректными данными. Кликаем по Submit. 
Given User choose 'Elements' category
When User clicks 'Text Box' menu button
Then 'Text Box' page is displayed
When User fills the fields with the following values: 
| Full Name | Email          | Current Address | Permanent Address |
| test      | test@email.com | test ad         | test permAd       |
And User clicks 'Submit' button
# Проверяем что все данные в появившейся таблице равны ранее введенным.
Then the following table is in the response
| Full Name | Email          | Current Address | Permanent Address |
| test      | test@email.com | test ad         | test permAd       |

## Раздел Check Box
@checkbox
Scenario: Verify Chexbox Page title
Given User choose 'Elements' category
When User clicks 'Check Box' menu button
Then 'Check Box' page is displayed

@checkbox
Scenario: Verify that selected elements are displayed as text
Given User choose 'Elements' category
When User clicks 'Check Box' menu button
Then 'Check Box' page is displayed
# Развернуть папку Home
When User expands 'Home' folder 
# выбрать папку Desktop не разворачивая ее
And User selects 'Desktop' folder
Then User verifies that 'You have selected : desktop notes commands' is displayed for selected results
When User expands 'Documents' folder
# выбрать Angular и Veu из папки WorkSpace
And User expands 'WorkSpace' folder
And User selects 'Angular' folder
And User selects 'Veu' folder
# развернуть папку Office и по очереди кликнуть по каждому элементу в папке
And User expands 'Office' folder
And User selects 'Public' folder
And User selects 'Private' folder
And User selects 'Classified' folder
And User selects 'General' folder
# развернуть папку Downloads и потом выделить ее целиком (клик по имени папки).
And User expands 'Downloads' folder
And User selects 'Downloads' folder
# Проверить что в выводе получилось "You have selected : desktop notes commands angular veu office public private classified general downloads wordFile excelFile"
Then User verifies that 'You have selected : desktop notes commands angular veu office public private classified general downloads wordFile excelFile' is displayed for selected results

## Раздел Web Tables
@webtables
Scenario: Verify WebTables Page title
Given User choose 'Elements' category
When User clicks 'Web Tables' menu button
Then 'Web Tables' page is displayed

@webtables
Scenario: Verify that Salary column is displaying in ascending order
# Кликнуть по столбцу Salary. 

# Проверить что значения в столбце Salary расположены по возрастанию.


@webtables
Scenario: Verify deleting rows
# Удалить вторую строку(имя Alden). 

# Проверить что в таблице осталось только две строки

# и что среди значений в столбце Department нет значения "Compliance"


## Раздел Buttons
@buttons
Scenario:BBBBBB

