@echo off
::set /p name=Enter your name: 
set name1=bhushan
echo %name1%
set message=Hello World 
echo %message%
pause

if %name1% == bhushan (
  echo Hello, shashi!
  echo %name1% Minnesota
) else (
  echo Hello, stranger!
)
pause
