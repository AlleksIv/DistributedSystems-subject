param($installPath, $toolsPath, $package, $project)

$project.Object.References | Where-Object { $_.Name -eq 'Alachisoft.NCache.SignalR' } | ForEach-Object { $_.Remove() }