////$(function (e) {
////    $(document).on("click", ".delete-btn", function (e) {
////        e.preventDefault();

////        let url = $(this).attr("href");

////        Swal.fire({
////            title: 'Are you sure?',
////            text: "You won't be able to revert this!",
////            icon: 'warning',
////            showCancelButton: true,
////            confirmButtonColor: '#3085d6',
////            cancelButtonColor: '#d33',
////            confirmButtonText: 'Yes'
////        }).then((result) => {
////            if (result.isConfirmed) {
               
////                Swal.fire(
////                    'Deleted!',
////                    ' Has been deleted.',
////                    'success'
////                )
////            }
////        })
////    })
////})
$(function () {
    $('.delete-sweet').on('click', function (e) {
        e.preventDefault();
        let url = $(this).attr("href");
        console.log(url);
        swal(
            { title: "Are you sure?", text: "You will not be able to recover this data after deletion!!", icon: "warning", buttons: true, dangerMode: true }
        ).then((willDelete) => {
            if (willDelete) {
                swal("Poof! data deleted!", { icon: "success" });
                fetch(url)
                    .then(response => response.text())
                    .then(data => {
                        window
                            .location
                            .reload()
                    })
                return true;
            } else {
                return false;
            }
        });
    })


    $('.submit-sweet').on('click', function (e) {
        e.preventDefault();
        let url = $(this).attr("href");
        console.log(url);
        swal(
            { title: "Your work has been saved", text: "You will not be able to recover this data after deletion!!", icon: "success", buttons: true }
        ).then((willDelete) => {
            if (willDelete) {
                swal("Success!created!", { icon: "success" });
                fetch(url)
                    .then(response => response.text())
                    .then(data => {
                        window
                            .location
                            .reload()
                    })
                return true;
            } else {
                return false;
            }
        });
    })
    $('.status-sweet').on('click', function (e) {
        e.preventDefault();
        let url = $(this).attr("href");
        console.log(url);
        swal(
            { title: "Are you sure?", text: "Change Status!!", icon: "warning", buttons: true, dangerMode: true }
        ).then((willDelete) => {
            if (willDelete) {
                swal("Status Changed!", { icon: "success" });
                fetch(url)
                    .then(response => response.text())
                    .then(data => {
                        window
                            .location
                            .reload()
                    })
                return true;
            } else {
                return false;
            }
        });
    });
})