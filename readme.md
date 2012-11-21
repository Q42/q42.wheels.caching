Q42.wheels.caching
=========
This repository contains the sourcecode of the following Nuget packages:
* Q42.Wheels.Caching
* Q42.Wheels.Caching.Memcached

Q42.Wheels.Caching
=========
This package contains an Interface (ICacheService) to use as the base for caching services. It contains the following implementations:
* MockCacheService (uses an in memory dictionary to store objects and retrieve those)
* RuntimeCacheService (Is an adapter on the System.Runtime.Caching.MemoryCache)
* ZeroCacheService (does not cache anything)

Q42.Wheels.Caching.Memcached
=========
Contains an implementation for creating a Memcached cache service. This seperation into two nuget packages is due to the dependencies on log4net & Memcached packages which are only required for Memcached.

HOW TO COMPILE
=========

PREREQUIREMENTS
----------------
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
=========
Original version by [Mark van Straten - Q42.nl](http://www.q42.nl/mark-van-straten)
Sourcecode located at [github.com](https://github.com/Q42/q42.wheels.caching.git - git@github.com:Q42/q42.wheels.caching.git
This software is kindly granted to the community and licensed under GNU GPL-3.0 - see supplied LICENSE.TXT for details    