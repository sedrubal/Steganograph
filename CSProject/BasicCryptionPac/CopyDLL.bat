
set targetProject=C:\Users\Basti\Documents\Visual Studio 2013\Projects\Steganograph\Steganograph\
set thisDLLName=BasicCryptionPac


del "%targetProject%bin\Debug\%thisDLLName%.dll" /q
if exist "bin\Debug\%thisDLLName%.dll" (goto copydebug) else (goto release)
:copydebug
Copy /Y "bin\Debug\%thisDLLName%.dll" "%targetProject%bin\Debug\"

:release
del "%targetProject%bin\Release\%thisDLLName%.dll" /q
if exist "bin\Release\%thisDLLName%.dll" (goto copyrelease) else (goto exitcode)
:copyrelease
Copy /Y "bin\Release\%thisDLLName%.dll" "%targetProject%bin\Release\"

:exitcode