<!DOCTYPE html>
<html>
<head>
<h1>IT 101 Final Project</h1>
</head>
<body>
<h3>***IN ORDER TO RUN THIS APPLICATION YOU WILL NEED MICROSOFT VISUAL STUDIO***</h3>
<h6>Problem Statement:</h6>
<p>Write a payroll program for the Lick2theStickLollipops Company. Located in Cincinnati, Ohio and has employees that live in OH, Indy, and KY. Company has salaried (manager) and hourly employees. Application should assist the payroll clerk in doing her weekly (52 times a year) payroll.</p>
<p>Application will allow the clerk to state if the payroll is salaried or hourly. Then the clerk will gain access to the proper form and enter first, last name, and necessary data for type of employee to provide:  Gross Pay, FICA, State Taxes, Federal Taxes, and Net Pay.</p>
<p>Daily Total of Gross Pay and Net Pay that combine both Salaried and Hourly Employees must be accessible.</p>
<h6>Gross Pay for Salaried Employees:</h6>
<p>The clerk will provide the yearly salary. Will be determinded by salary divided by the number of payrolls per year</p>
<h6>Gross Pay for Hourly Employees:</h6>
<p>The clerk will provide hours worked for pay period and hourly wage. Gross pay is based on hours worked and hourly wage. Employee will be paid time and a half for all hours over 40 in a week.</p>
<h6>FICA: (Sum of)</h6>
<p>Social Security is 6.2% of the first 125,000 of Yearly Gross Pay (Social Security tax). After employee has accumulated over $125,000 in yearly gross pay, they do not pay Social Security Tax. For each payroll the payroll clerk will provide the cumulative Yearly Gross Pay that has accumulated prior to the current payroll for that year</p>
<p>Medicare which is 1.45% of total Gross Pay.</p>
<h6>State Taxes:</h6>
<table border="1">
  <tr>
    <th>For Ohio:</th>
    <th>For Kentucky:</th>
    <th>For Indiana:</th>
  </tr>
  <tr>
    <td>6.5% of Weekly Gross Pay</td>
    <td>6.0%	of Weekly Gross Pay</td>
    <td>5.5% of Weekly Gross Pay</td>
  </tr>
</table>
<h6>Federal Taxes:</h6>
<table border="1">
  <tr>
    <th>Weekly Gross Pay Income Tax</th>
    <th>Withheld based on the Weekly Gross Pay</th>
  </tr>
  <tr>
    <td>$0 to $50</td>
    <td>$0</td>
  </tr>
  <tr>
    <td>$50 to $500</td>
    <td>10%  of amount over $50</td>
  </tr>
  <tr>
    <td>$500 to $2,500</td>
    <td>$45.00 + 15% of amount over $500.00</td>
  </tr>
  <tr>
    <td>$2,500 to $5,000</td>
    <td>$345.00 + 20% of amount over $2,500</td>
  </tr>
  <tr>
    <td>Over $5,000</td>
    <td>$845.00 + 25% of amount over $5,000</td>
  </tr>
</table>
<h6>Net Pay:</h6>
<p>Gross Pay – FICA – State Taxes – Federal Taxes</p>
<h1>Test Cases</h1>
<img src="/images/frmMenu.jpg" alt="image of the menu form" title="frmMenu.jpg">
<img src="/images/testCase0.jpg" alt="image of the first test case" title="testCase0.jpg">
<img src="/images/testCase0daily.jpg" alt="image of the daily totals after first test case" title="testCase0daily.jpg">
<img src="/images/testCase1.jpg" alt="image of the second test case" title="testCase1.jpg">
<img src="/images/testCase1daily.jpg" alt="image of the daily totals after second test case" title="testCase1daily.jpg">
<img src="/images/testCase2.jpg" alt="image of the third test case" title="testCase2.jpg">
<img src="/images/testCase2daily.jpg" alt="image of the daily totals after third test case" title="testCase2daily.jpg">
<img src="/images/testCase3.jpg" alt="image of the fourth test case" title="testCase3.jpg">
<img src="/images/testCase3daily.jpg" alt="image of the daily totals after fourth test case" title="testCase3daily.jpg">
</body>
</html>
