#!/bin/bash


curl localhost:5000/v1/shopping-list | jq
curl --request POST -H 'content-type:application/json' localhost:5000/v1/shopping-list -d '"ham"' | jq
curl localhost:5000/v1/shopping-list | jq

