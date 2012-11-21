Q42.wheels.caching
===========================
This repository contains the sourcecode of the following Nuget packages:
* Q42.Wheels.Caching
* Q42.Wheels.Caching.Memcached

This seperation is due to the dependencies on log4net & Memcached packages which are only required for the Memcached part.

PREREQUIREMENTS
===========================
* Visual Studio 2010 SP1 or Visual Studio 2012

GIT FLOW
----------------
This repository uses git flow as development model. For more information see http://nvie.com/posts/a-successful-git-branching-model/

* Tested with Nant 0.86 - [http://nant.sourceforge.net/]
* Google App Engine Java SDK - [https://developers.google.com/appengine/downloads]
* Nant setup correctly on your PATH

HOW TO COMPILE
----------------
* bump version of compiled DLL in AssemblyInfo.cs for the package required (Q42.Wheels.Caching or Q42.Wheels.Caching.Memcached)
* build it with visual studio
* Your nupkg file will be created in {project}\bin\{configuration}


LICENSE
===========================
Original version by [Mark van Straten - Q42.nl](http://www.q42.nl/mark-van-straten)
Sourcecode located at [github.com](https://github.com/Q42/q42.wheels.caching.git - git@github.com:Q42/q42.wheels.caching.git
This software is kindly granted to the community and licensed under GNU GPL-3.0 - see supplied LICENSE.TXT for details    