# Google Analytics

Google Analytics is a view layer upon a huge table

Data differentiation types:
- dimensions - text data characteristics (letters)
- metrics - numeric data characteristics (numbers)

GA based on cookies. The GA cookie example: `GA.1.2.1808482521.1486727369` where
- `GA.1.2` is always same. It's a version of GA
- `1808482521` is random number
- `1486727369` is timestamp when you visited a website for the first time

`1808482521` + `1486727369` is user ID

**Basic metics:** users, browsers, sessions, conversion rate

A 'user' corresponds to a browser

Session is a groups of interaction with website. Session expires at midnight, when you come to website from different campaign, inactivity window (30 mins)

Conversion rate is amount of sessions that completed a goal. For example: creating of order

Bounce rate is the percentage of single page sessions. It's number of sessions during which only one page was viewed regardless how much time you've spent there. High bounce rate for some pages is absolutely OK

Time measurements allows to understand how much time a user has spent on website. Time measurements for last viewed pages is not calculated

Unique events are calculated per session

Exit rate vs Bounce rate. Every bounce is exit. But not all exits are bounces. Exit is calculated only in a case that particular page was viewed and also was last page of the session. Bounce rate is calculated when only the one page was viewed during the session

Pages with highest exit rates are killers of sessions

**UTM** parameters enable us to distinguish between various traffic chanel

Parameters:
- utm_source - domain, ad-platform name. Example: google, instagram, freshlife28
- utm_medium - ad type. Example: post, banner, page search campaign (cpc)
- utm_campaign - campaign name. Example: ga-course. It's your own indemnificator of campaign
- utm_content - ad detail (creative, banner size). Example: benefits. This name allows to distinguish banners, videos or words
- utm_term - keyword. Example: google+analytics+course. It should be used only for page search campaign

## Google analytics tabs

**Audience** allows to understand what gender, os, browsers, screen resolution of users visiting website

**Behavior** allows to understand what pages need to improvement, what a user does on website, what pages give the most of revenue

## What to check?

- Audience -> Technology -> Browsers & OS. Check what OS, browser, screen resolution gives you the best conversion rate. If there is a huge differences then the website might have a problem
- Audience -> Geo -> Language. Check how many users can use not localized website
- Mobile users * screen resolutions
- Behavior -> Site Content -> All pages -> Navigation summary. Allows to see what a user does on a page
- Conversion -> Multi-channel funnels -> Time lag. Allows to see how many days is took from the first interaction to conversion
