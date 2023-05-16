@qd @widgets
Feature: Widgets Category
Widgets caregory page
Tests perfomed for Auto Complete and Progress Bar subpages

Background: Navigate to Forms Categoty page
Given User navigates to 'https://demoqa.com/'
When User choose 'Widgets' category
Then 'Widgets' page is displayed

@autocomplete
Scenario: Auto Complete subpage - suggestions
When User clicks 'Auto Complete' menu button
Then 'Auto Complete' page is displayed
# Ввести в поле "Type multiple color names" букву "g"
When User fills 'g' into 'Type multiple color names' field
# Проверить что всего автокомплит предложил три варианта и что в каждом из них была буква 'g'.
Then User verifies that '3' suggestion options are displayed
And User verifies that each suggestion contains 'g'

@autocomplete
Scenario: Auto Complete subpage - add and delete options
When User clicks 'Auto Complete' menu button
Then 'Auto Complete' page is displayed
# Добавить в поле "Type multiple color names" следующие цвета: 
# Red, Yellow, Green, Blue, Purple. 
When User adds 'Red' into 'Type multiple color names' field
And User adds 'Yellow' into 'Type multiple color names' field
And User adds 'Green' into 'Type multiple color names' field
And User adds 'Blue' into 'Type multiple color names' field
And User adds 'Purple' into 'Type multiple color names' field
# После этого удалите Yellow и Purple.
And User deletes 'Yellow' item
And User deletes 'Purple' item
# Проверить что в поле остались только Red, Green, Blue.
Then User verifies that 'Red' item is displayed
And User verifies that 'Green' item is displayed
And User verifies that 'Blue' item is displayed

@progressBar
Scenario: Progress Bar - Reset/Start buttons
When User clicks 'Progress Bar' menu button
Then 'Progress Bar' page is displayed
# Кликнуть по Start и дождатся пока полоска не станет 100%.
When User clicks 'Start' button
Then User verifies that 'Stop' button name is displayed
When User waits until the Progress Bar value reaches '100%'
# Далее проверяем, что кнопка изменила название на Reset. 
Then User verifies that 'Reset' button name is displayed
And Progress Bar value is '100%'
# После этого кликнуть по Reset. 
When User clicks 'Reset' button
#Проверить что кнопка Reset стала Start, а значение в прогрес баре равно 0%.
Then User verifies that 'Start' button name is displayed
And Progress Bar value is '0%'