# Description
Simple utility to check all files exist
# How to use
You can just run it and enter params in console. Also You can pass params:
```
dotnet OrderValidator.dll -i:"%inputFolder%" -m:"%searchPattern%" -silent:true
```
Where
- %inputFolder% is Your folder with files

(example: C:\users\user\desktop\folder\\);
- %searchPattern% can contain a combination of valid literal path and wildcard (* and ?) characters, but it doesn't support regular expressions

 (example: * - get all files; *.png - get all png images);
- -silent is additional parameter. Use it to hide additional info from console output.

## Examples of usage
Run and enter params in console:
![example](https://user-images.githubusercontent.com/60701982/161411449-f5c0ea4d-e9bf-47c4-9ee0-12bff3097489.png)
Run utility with params:
![example with params](https://user-images.githubusercontent.com/60701982/161411456-a1671437-5807-4d8e-b0be-2fe878b1a3ed.png)
When You have multiple groups in input folder result can be like this:
![example with params (multiple groups in input folder)](https://user-images.githubusercontent.com/60701982/161411717-34cd314a-b77e-481e-a26a-c69d31862a87.png)

