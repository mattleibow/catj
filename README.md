# catj

[![Build Status](https://dev.azure.com/mattleibow/OpenSource/_apis/build/status/catj?branchName=master)](https://dev.azure.com/mattleibow/OpenSource/_build/latest?definitionId=17&branchName=master) ![Nuget (with prereleases)](https://img.shields.io/nuget/vpre/catj.svg) 

Displays JSON files in a flat format.

Input:

```
{
  "mappings": {
    "templates": [
      {
        "fields": {
          "mapping": {
            "norms": false,
            "type": "text",
            "fields": {
              "keyword": {
                "ignore_above": 256,
                "type": "keyword"
              }
            }
          }
        }
      }
    ]
  }
}
```

Output:

```
.mappings.templates[0].fields.mapping.norms = False
.mappings.templates[0].fields.mapping.type = "text"
.mappings.templates[0].fields.mapping.fields.keyword.ignore_above = 256
.mappings.templates[0].fields.mapping.fields.keyword.type = "keyword"
```
