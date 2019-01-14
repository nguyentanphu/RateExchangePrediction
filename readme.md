# A WinForm app which utilize the openexchangerates.org to make prediction in future !!!

Additional features:
- Choose new sample size, specifying from date and to date.
- Monthly mode and daily mode: Monthly will accumulate api monthly (getting rates of 15th date of each month), while in daily, rates will be fetch day by day basis.
R squared indicator: show how accurate the linear regression is base on input sample.

**How accurate is the predictor? How could we make it more accurate?**

I Included the R squared in the implementation of the app. R squared is a technique that show the accuracy of linear regression base on the distance of the estimated values and actual values to the mean value.
Value of R squared is between 0 and 1. Closer to 1 means more accuracy, closer to 0 means less accuracy. Sample input of 'The predicted currency exchange from USD to TRY for 15/1/2017 is 3.263.' gives R squared: 0.4708, which is not so accurate.

We can make the prediction more accurate by using larger sample size like from 15/1/2016 to 15/12/2018 (monthly). Also, I believe if we want to predict near future (e.g. 2019,2020), we should have recent sample (e.g. 2016,2017,2018) rather than old sample (e.g. 2000,2001).