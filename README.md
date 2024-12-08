
# Loading Spinner Component for Blazor

This is a Blazor component for displaying a customizable loading spinner with an overlay. It can be used to indicate that a page or part of a page is loading. The component is designed to be easily reusable and flexible, with options for customizing the spinner's color, overlay color, and whether the overlay should cover the whole page or just a specific section.

## Features

- Display a loading spinner with a customizable overlay.
- Optionally cover the entire page or just a part of it.
- Configurable colors for the spinner and overlay.

## Installation

To use this component, you can install it as a NuGet package.

1. Open your Blazor project in Visual Studio or your preferred IDE.
2. Install the NuGet package from the NuGet Gallery:

      ```bash
   dotnet add package BlazorLoadingSpinner
   ```

## Usage
### With Full Page Overlay
   ```html
   @using [Your Namespace].Components
    
   @* Some page in your app *@ 
   <LoadingSpinner IsLoading="@isLoading" FullPage="@true"></LoadingSpinner>
  
   @code {
      private bool isLoading = true;
    
       // ... (your logic to control isLoading)
   }
   ```

### With Section Overlay
   ```html
   @using [Your Namespace].Components
    
   @* Some page in your app *@ 
   <LoadingSpinner IsLoading="@isLoading" FullPage="@false">
       @* Place the section that should be covered by overlay in here*@     
        <div>blablabla</div>
   </LoadingSpinner>
  
   @code {
      private bool isLoading = true;
    
       // ... (your logic to control isLoading)
   }
   ```

### Parameters

-   `IsLoading` (bool): Controls whether the loading spinner is displayed. Set this to `true` when you want to show the spinner and `false` when you want to hide it.
-   `ChildContent` (RenderFragment): The content to display when the spinner is not active.
-   `FullPage` (bool): If set to `true`, the spinner will cover the full page. If `false`, it the part that is passed in as `ChildContent` (passed in between the opening and closing `LoadingSpinner` tag).
-   `OverlayColor` (Color): The color of the overlay (background). Default is a semi-transparent black (`rgba(0, 0, 0, 0.7)`).
-   `SpinnerColor` (Color): The color of the spinner. Default is a semi-transparent white (`rgba(255, 255, 255, 0.4)`).

## License
This project is licensed under the Apache License 2.0. See the LICENSE file for details.

## License
This project is licensed under the Apache License 2.0. See the LICENSE file for details.
