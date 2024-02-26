To add reference to a project manually

- copy the .dll to the bin/Debug/net\*.0
- add this :
  <ItemGroup>
  <Reference Include="{namesapce}">
  <HintPath>..\..\..\Downloads\TextFileReader\TextFile.dll</HintPath>
  </Reference>
  </ItemGroup>
