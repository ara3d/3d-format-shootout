# 3D Format Shoot-out

A set of benchmarks, tests, profiling tools, and sample data for comparing static 3D scene data formats.

# About

This project aims to provide a set of tools for measuring and comparing the capabilities of numerous data/file formats
to process large amounts of static instanced 3D geometry. 

The goal of this project is to understand objectively the tradeoffs involved in the different formats for use in representing 
large AEC data sets, and how they scale for different types of tasks and input. 

We will not be evaluating formats for their ability to convey animations or materials. 

# Motivation

Sufficiently large representations of geometry used in CAD and AEC applications, either take extremely large amounts of time to process 
or will crash the software. This investigation will examine the capabilities of a number of implementations of different format readers and 
writers. 

Rather than relying on anecdotal experience and marketing when choosing a 3D representation, this project aims to provide users and implementors 
with a concrete set of benchmarks to use and compare against when implementing formats.   

# Methodology 

Benchmarking and profiling data formats accurately is impossible because we can only really measure the performance of a particular 
implementation. While the implementation quality is influenced by the data format many other factors will influence the results. 
Therefore this is more accurately would be described as a survey and analysis of 3D data format _implementations_. 

## Languages Used

We use only open-source JavaScript, WASM, C#, and C++ libraries.     

## Tasks and Measurments

* For reach file in the data set we will use various libraries and tools to compute the time and memory consumption to open file and compute:
  * Number of polygons, vertices, indices, meshes (distinct and instanced)
  * average polygon size (total and per-mesh)
  * bounding boxes: globally, total, bounding box
  * average UV coordinate size
  * convert into other formats
  * recognize the file format 
  * find and extract a subset of data
  * modify some part of the data and write it out again.  
 
## Format Information

* For reach format we will report on: 
  * Support across tools and libraries  
  * Ability to handle different features 
  * References to the specification, and implementations used
  * Binary or text.
  * Availability of reference implementations 

## Data Sets

* Instanced data
* Data with 0, 1, or 2 UV channels
* Data with UVW channels 
* Mixed meshes no instancing
* Conversion time into other format
* Data loss when round-tripped 
* Multiple
* Single and double precisions

## Additional Tasks 

* Represent 2D shapes
* Colored/not-colored
* Point clouds
* Particle sets
* Embedded materials
* Embedded textures 
  
## Formats Considered 

* GLB / glTF
* DAE (Collada)
* OBJ
* STL
* PLY
* FBX
* G3D
* U3D
* USD / USDZ
* Datasmith
* DRC - Draco
* IGES
* MAX - 3ds Max native format
* 3DS
* ABC - Alembic

# Particle and Point Cloud Specific

* PRT
* XYZ
* E57 

# AEC/CAD Specific Formats

* VIM
* IFC
* BIM 
* STEP
* SVF / SVF2
* DWG 
* 3DM - Rhino format
* DXF -
* 3MF 

