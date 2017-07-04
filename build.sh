#!/bin/bash
git diff
git status
git add -A
git status 
git commit -m $1
git status
echo "Git Has Added, Commited and Finished gitting your project"