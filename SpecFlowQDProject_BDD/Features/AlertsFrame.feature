@qd @alerts
Feature: Alerts, Frame & Windows
Alerts, Frame & Windows caregory page
Tests perfomed for: Browser Windows

Background: Navigate to Alerts, Frame & Windows Categoty page
	Given User navigates to 'https://demoqa.com/'
	Given User choose 'Alerts, Frame & Windows' category
	Then 'Alerts, Frame & Windows' page is displayed

@browserWindows
Scenario: Browser Windows - New Tab
	When User clicks 'Browser Windows' menu button
	Then 'Browser Windows' page is displayed
	#Сделать клик по кнопке, 
	When User clicks 'New Tab' button
	# переключить фокус на новое окно 
	And User switches focus to the new tab
	# и проверить что на странице присутствует корректный текст (например "This is a sample page").
	Then 'This is a sample page' text is displayed on the new tab

@browserWindows
Scenario Outline: Browser Windows - New Window
	When User clicks 'Browser Windows' menu button
	Then 'Browser Windows' page is displayed
	When User clicks 'New Window' button
	And User switches focus to the new window
	Then '<expected_text>' is displayed on the new window
	Examples:
| expected_text             |
| This is a sample page     |
| This is not a sample page |