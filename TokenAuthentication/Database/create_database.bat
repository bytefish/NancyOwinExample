@echo off

:: Copyright (c) Philipp Wagner. All rights reserved.
:: Licensed under the MIT license. See LICENSE file in the project root for full license information.

set PGSQL_EXECUTABLE="C:\Program Files\PostgreSQL\9.4\bin\psql.exe"
set STDOUT=stdout.log
set STDERR=stderr.log
set LOGFILE=query_output.log

set HostName=localhost
set PortNumber=5432
set DatabaseName=sampledb
set UserName=philipp
set Password=

call :AskQuestionWithYdefault "Use Host (%HostName%) Port (%PortNumber%) [Y,n]?" reply_
if /i [%reply_%] NEQ [y] (
	set /p HostName="Enter HostName: "
	set /p PortNumber="Enter Port: "
)

call :AskQuestionWithYdefault "Use Database (%DatabaseName%) [Y,n]?" reply_
if /i [%reply_%] NEQ [y]  (
	set /p ServerName="Enter Database: "
)

call :AskQuestionWithYdefault "Use User (%UserName%) [Y,n]?" reply_
if /i [%reply_%] NEQ [y]  (
	set /p UserName="Enter User: "
)

set /p PGPASSWORD="Password: "

1>%STDOUT% 2>%STDERR% (

	:: Schemas
	%PGSQL_EXECUTABLE% -h %HostName% -p %PortNumber% -d %DatabaseName% -U %UserName% < 01_Schemas/schema_auth.sql -L %LOGFILE%
	
	:: Tables
	%PGSQL_EXECUTABLE% -h %HostName% -p %PortNumber% -d %DatabaseName% -U %UserName% < 02_Tables/tables_auth.sql -L %LOGFILE%
	
	:: Keys
	%PGSQL_EXECUTABLE% -h %HostName% -p %PortNumber% -d %DatabaseName% -U %UserName% < 03_Keys/keys_auth.sql -L %LOGFILE%
	
	:: Security
	%PGSQL_EXECUTABLE% -h %HostName% -p %PortNumber% -d %DatabaseName% -U %UserName% < 05_Security/security_auth.sql -L %LOGFILE%
	
	:: Data
	%PGSQL_EXECUTABLE% -h %HostName% -p %PortNumber% -d %DatabaseName% -U %UserName% < 06_Data/data_auth.sql -L %LOGFILE%
)

goto :end

:: The question as a subroutine
:AskQuestionWithYdefault
	setlocal enableextensions
	:_asktheyquestionagain
	set return_=
	set ask_=
	set /p ask_="%~1"
	if "%ask_%"=="" set return_=y
	if /i "%ask_%"=="Y" set return_=y
	if /i "%ask_%"=="n" set return_=n
	if not defined return_ goto _asktheyquestionagain
	endlocal & set "%2=%return_%" & goto :EOF

:end
pause