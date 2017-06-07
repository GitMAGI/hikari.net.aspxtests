/* ------------------------------------------------------------------------------
*
*  # Fullcalendar basic options
*
*  Specific JS code additions for extra_fullcalendar_views.html and 
*  extra_fullcalendar_styling.html pages
*
*  Version: 1.0
*  Latest update: Aug 1, 2015
*
* ---------------------------------------------------------------------------- */

$(function() {
    // Add events
    // ------------------------------

    /*

    // Default events
    var events = [
        {
            title: 'Occupato',
            start: '2014-11-01'
        },
        {
            title: 'Long Event',
            start: '2014-11-07',
            end: '2014-11-10'
        },
        {
            id: 999,
            title: 'Repeating Event',
            start: '2014-11-09T16:00:00'
        },
        {
            id: 999,
            title: 'Repeating Event',
            start: '2014-11-16T16:00:00'
        },
        {
            title: 'Conference',
            start: '2014-11-11',
            end: '2014-11-13'
        },
        {
            title: 'Meeting',
            start: '2014-11-12T10:30:00',
            end: '2014-11-12T12:30:00'
        },
        {
            title: 'Lunch',
            start: '2014-11-12T12:00:00'
        },
        {
            title: 'Meeting',
            start: '2014-11-12T14:30:00'
        },
        {
            title: 'Happy Hour',
            start: '2014-11-12T17:30:00'
        },
        {
            title: 'Dinner',
            start: '2014-11-12T20:00:00'
        },
        {
            title: 'Birthday Party',
            start: '2014-11-13T07:00:00'
        },
        {
            title: 'Click for Google',
            url: 'http://google.com/',
            start: '2014-11-28'
        }
    ];
    
    // Event colors
    var eventColors = [
        {
            title: 'Occupato',
            start: '2016-11-03',
            color: '#FF9800'
        },
        {
            title: 'Seleziona',
            start: '2016-11-03',
            color: '#5C6BC0'
        },
        {
            title: 'Occupato',
            start: '2016-11-04',
            color: '#FF9800'
        },
        {
            title: 'Occupato',
            start: '2016-11-04',
            color: '#FF9800'
        },
        {
            title: 'Occupato',
            start: '2016-11-07',
            color: '#FF9800'
        },
        {
            title: 'Occupato',
            start: '2016-11-07',
            color: '#FF9800'
        },
        {
            title: 'Seleziona',
            start: '2016-11-08',
            color: '#5C6BC0'
        },
        {
            title: 'Occupato',
            start: '2016-11-08',
            color: '#FF9800'
        },
        {
            title: 'Seleziona',
            start: '2016-11-10',
            color: '#5C6BC0'
        },
        {
            title: 'Seleziona',
            start: '2016-11-10',
            color: '#5C6BC0'
        },
        {
            title: 'Seleziona',
            start: '2016-11-11',
            color: '#5C6BC0'
        },
        {
            title: 'Occupato',
            start: '2016-11-11',
            color: '#FF9800'
        },
        {
            title: 'Seleziona',
            start: '2016-11-14',
            color: '#5C6BC0'
        },
        {
            title: 'Seleziona',
            start: '2016-11-14',
            color: '#5C6BC0'
        },
        {
            title: 'Occupato',
            start: '2016-11-15',
            color: '#FF9800'
        },
        {
            title: 'Seleziona',
            start: '2016-11-15',
            color: '#5C6BC0'
        },
        {
            title: 'Seleziona',
            start: '2016-11-17',
            color: '#5C6BC0'
        },
        {
            title: 'Seleziona',
            start: '2016-11-17',
            color: '#5C6BC0'
        },
        {
            title: 'Ocupato',
            start: '2016-11-18',
            color: '#FF9800'
        },
        {
            title: 'Seleziona',
            start: '2016-11-18',
            color: '#5C6BC0'
        },
        {
            title: 'Seleziona',
            start: '2016-11-21',
            color: '#5C6BC0'
        },
        {
            title: 'Seleziona',
            start: '2016-11-21',
            color: '#5C6BC0'
        },
        {
            title: 'Seleziona',
            start: '2016-11-22',
            color: '#5C6BC0'
        },
        {
            title: 'Seleziona',
            start: '2016-11-22',
            color: '#5C6BC0'
        },
        {
            id: '234343',
            title: 'Seleziona',
            start: '2016-11-24',
            url: 'http://pic.hltmanagement.org/pic-in-preparazione.html',
            color: '#5C6BC0'
        },
        {
            title: 'Seleziona',
            start: '2016-11-24',
            color: '#5C6BC0'
        },
        {
            title: 'Seleziona',
            start: '2016-11-25',
            color: '#5C6BC0'
        },
        {
            title: 'Seleziona',
            start: '2016-11-25',
            color: '#5C6BC0'
        },
        {
            title: 'Seleziona',
            start: '2014-11-27',
            color: '#5C6BC0'
        },
        {
            title: 'Seleziona',
            start: '2016-11-28',
            color: '#5C6BC0'
        },
        {
            title: 'Seleziona',
            start: '2016-11-28',
            color: '#5C6BC0'
        },
        {
            title: 'Seleziona',
            start: '2016-11-29',
            color: '#5C6BC0'
        },
    ];
    
    // Event background colors
    var eventBackgroundColors = [
        {
            title: 'All Day Event',
            start: '2014-11-01'
        },
        {
            title: 'Long Event',
            start: '2014-11-07',
            end: '2014-11-10',
            color: '#DCEDC8',
            rendering: 'background'
        },
        {
            id: 999,
            title: 'Repeating Event',
            start: '2014-11-06T16:00:00'
        },
        {
            id: 999,
            title: 'Repeating Event',
            start: '2014-11-16T16:00:00'
        },
        {
            title: 'Conference',
            start: '2014-11-11',
            end: '2014-11-13'
        },
        {
            title: 'Meeting',
            start: '2014-11-12T10:30:00',
            end: '2014-11-12T12:30:00'
        },
        {
            title: 'Lunch',
            start: '2014-11-12T12:00:00'
        },
        {
            title: 'Happy Hour',
            start: '2014-11-12T17:30:00'
        },
        {
            title: 'Dinner',
            start: '2014-11-24T20:00:00'
        },
        {
            title: 'Meeting',
            start: '2014-11-03T10:00:00'
        },
        {
            title: 'Birthday Party',
            start: '2014-11-13T07:00:00'
        },
        {
            title: 'Vacation',
            start: '2014-11-27',
            end: '2014-11-30',
            color: '#FFCCBC',
            rendering: 'background'
        }
    ];

    */

    function successo(data) {
        console.log(data);
        //eventColors = data;

        // Event colors
        $('.fullcalendar-event-colors').fullCalendar({
            header: {
                left: 'prev,next',
                center: 'title',
                right: 'month,agendaWeek'
            },
            defaultDate: '2017-03-23',
            editable: true,
            events: data
        });
    }
    function errore(XMLHttpRequest, textStatus, errorThrown) {
        //console.log(XMLHttpRequest);
        //console.log(textStatus);
        //console.log(errorThrown);
        //alert(errorThrown);
    }

    function calendarInitializer(categoriaEsame_)
    {
        console.log("Mi chiami!");
        condole.log(categoriaEsame_);

        $.ajax({
            type: "POST",
            url: "/AjaxHandler.ashx?param=PicContainer.aspx",
            data: { categoria: categoriaEsame_ },
            success: successo,
            error: errore,
            //dataType: "application/json",
            dataType: "json",
            accepts: { json: "application/json" }
        });
    }

    /*
    // Initialization
    // ------------------------------

    // Basic view
    $('.fullcalendar-basic').fullCalendar({
        header: {
            left: 'prev,next today',
            center: 'title',
            right: 'month,basicWeek,basicDay'
        },
        defaultDate: '2014-11-12',
        editable: true,
        events: events
    });

    // Agenda view
    $('.fullcalendar-agenda').fullCalendar({
        header: {
            left: 'prev,next today',
            center: 'title',
            right: 'month,agendaWeek,agendaDay'
        },
        defaultDate: '2016-11-21',
        defaultView: 'agendaWeek',
        editable: true,
        events: events
    });

    // Event background colors
    $('.fullcalendar-background-colors').fullCalendar({
        header: {
            left: 'prev,next today',
            center: 'title',
            right: 'month,agendaWeek,agendaDay'
        },
        defaultDate: '2016-11-21',
        editable: true,
        events: eventBackgroundColors
    });
    */
});
