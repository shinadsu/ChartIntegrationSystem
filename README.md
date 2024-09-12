# Chart

Chart is a cross-platform mobile application developed using .NET MAUI. This app is designed to manage and display posts. Future plans include integration with Firebase for push notifications and REST API for full CRUD operations.

## Features

- **Main Page**: The main interface where users can view posts.
- **Post Page**: A dedicated page for individual posts.
- **About Page**: Information about the application and its purpose.

## Installation

1. Clone the repository:
    ```sh
    git clone https://github.com/yourusername/chart.git
    ```
2. Navigate to the project directory:
    ```sh
    cd chart
    ```
3. Restore the dependencies:
    ```sh
    dotnet restore
    ```
4. Build and run the project:
    ```sh
    dotnet build
    dotnet run
    ```

## Dependencies

The project relies on the following packages:

- [CommunityToolkit.Mvvm](https://www.nuget.org/packages/CommunityToolkit.Mvvm) - Version 8.2.2
- [Microsoft.Maui.Controls](https://www.nuget.org/packages/Microsoft.Maui.Controls) - Specified by `$(MauiVersion)`
- [Microsoft.Maui.Controls.Compatibility](https://www.nuget.org/packages/Microsoft.Maui.Controls.Compatibility) - Specified by `$(MauiVersion)`
- [Microsoft.Extensions.Logging.Debug](https://www.nuget.org/packages/Microsoft.Extensions.Logging.Debug) - Version 8.0.0
- [sqlite-net-pcl](https://www.nuget.org/packages/sqlite-net-pcl) - Version 1.9.172

## Platform Support

The application is designed to run on the following platforms:

- Android
- iOS
- Mac Catalyst
- Windows

## Planned Features

- **Firebase Integration**: To enable push notifications.
- **REST API Integration**: To support full CRUD operations on posts.

## Contributing

Contributions are welcome! Please open an issue or submit a pull request for any features or fixes.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.
