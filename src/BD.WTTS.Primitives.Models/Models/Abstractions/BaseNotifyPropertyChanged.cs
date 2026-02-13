namespace BD.WTTS.Models.Abstractions;

/// <summary>
/// BaseNotifyPropertyChanged is the base object for ViewModel classes, and it
/// implements INotifyPropertyChanged. In addition, ReactiveObject provides
/// Changing and Changed Observables to monitor object changes.
/// </summary>
public abstract class BaseNotifyPropertyChanged
#if MVVM_VM
    : ReactiveObject
#endif
{
#if MVVM_VM
    /// <inheritdoc cref="ReactiveObject.Changing"/>
    [IgnoreDataMember]
    [MP2Ignore]
#if __HAVE_N_JSON__
    [N_JsonIgnore]
#endif
#if !__NOT_HAVE_S_JSON__
    [S_JsonIgnore]
#endif
    public new IObservable<IReactivePropertyChangedEventArgs<IReactiveObject>> Changing => base.Changing;

    /// <inheritdoc cref="ReactiveObject.Changed"/>
    [IgnoreDataMember]
    [MP2Ignore]
#if __HAVE_N_JSON__
    [N_JsonIgnore]
#endif
#if !__NOT_HAVE_S_JSON__
    [S_JsonIgnore]
#endif
    public new IObservable<IReactivePropertyChangedEventArgs<IReactiveObject>> Changed => base.Changed;

    /// <inheritdoc cref="ReactiveObject.ThrownExceptions"/>
    [IgnoreDataMember]
    [MP2Ignore]
#if __HAVE_N_JSON__
    [N_JsonIgnore]
#endif
#if !__NOT_HAVE_S_JSON__
    [S_JsonIgnore]
#endif
    public new IObservable<Exception> ThrownExceptions => base.ThrownExceptions;
#endif
}
