rem protogen.exe -i:protos\ReturnMessage.proto -o:cs\ReturnMessage.cs
rem protogen.exe -i:protos\Login.proto -o:cs\Login.cs

rem ..\protogen.exe -i:..\protos\blokus.proto -o:..\..\..\Scripts\Common\Proto\blokus.cs


@echo off

SetLocal EnableDelayedExpansion

ECHO "gonna generate project specific protos..."

cd ..\

set tmp=..\..\Scripts\Common\Proto

if exist %tmp% ( ( RD /s /q %tmp% ) & ECHO "%tmp% deleted" )

IF not exist ( mkdir %tmp% & ECHO "%tmp% created" )

rem for %%i in (protos\*.proto) do (.\protogen.exe -i:%%i  -o:（这里需要转换） & echo %%i generate finish)

.\protogen.exe -i:protos\blokus.proto -o:%tmp%\blokus.cs

PAUSE