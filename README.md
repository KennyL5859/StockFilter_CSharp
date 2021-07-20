# StockFilter_CSharp
C# App that filters and analyzes stock data using Yahoo Finance api

This app uses Yahoo Finance API written by Karl Wan. The user can CRUD (Create, Read, Update, Delete) stock tickers. The tickers are stored in a .txt file inside the
Required folder within the app. 

Currently, there are 4 buttons which contain its own functionality.

The 50/200 MA button will take you to a new form, once on the new form, the user can select a range from 1-5% and select a radio button of 50MA or 200MA. Once the user 
clicks search, the app will loop through all the stock tickers in the main menu to see which stock's 50 day or 200 day moving averages is within 1-5%.

The trend button functionality lets user filter stocks from the stock lists that have gone certain number of days up or/and down. The User can pick how many days the stocks has 
gone either up or down or both. 

The earnings button functionality lets user see which stocks in his/her stock list have earnings coming up. The user picks a day range and the program will list all stocks that 
have earnings call coming up within that date range.

The volume button functionality lets user filter which stocks have certain number of days above its 3 month average volume. The user sets the day and range criteria. 

With all 4 functionality and the main page, the user can double-click on any ticker and this will take the user to a form which will graph the stock's prices. On the graph page, 
the user can check 50MA, 200MA, and volume. 
