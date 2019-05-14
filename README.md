[![Build status](https://dev.azure.com/dlundy0844/GithubTest/_apis/build/status/GithubTest-CI)](https://dev.azure.com/dlundy0844/GithubTest/_build/latest?definitionId=-1)

# Core.ApiSelectProperty
Quick and dirty sample of how to implement select properties in Api calls when for either security or bad architectural reasons you don't want to push the select parameters all the way down to your data layer. 

## Run as a .NET Core self hosted app

This should open up a new window in your browser and call the Api with no select query which should yield the below result. 

``` json
[
  {
    "Name": "Jim",
    "Title": "Boss",
    "Password": "Password"
  }
]
```

Then if you add a query string like so `http://localhost:60158/api/values?select=name,title` you should get the following result:

``` json
[
  {
    "Name": "Jim",
    "Title": "Boss"
  }
]
```
